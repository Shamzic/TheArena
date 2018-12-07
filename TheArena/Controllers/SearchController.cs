using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheArena.Models;
using TheArena.ViewModels;


namespace TheArena.Controllers
{
    public class SearchController : Controller
    {
        private TheArenaContext db = new TheArenaContext();
        

        // GET: Search
        public ActionResult Index(String search)
        {//
            var mymodel = new ViewModels.MultipleSearch();
            mymodel.Games = db.Game.Where(x => x.Name.Contains(search) || search == null).ToList();
            mymodel.Geeks = db.Geek.Where(x => x.Name.Contains(search) || search == null || x.Username.Contains(search) || x.Surname.Contains(search)).ToList();
            mymodel.Tournaments = db.Tournament.Where(x => x.Name.Contains(search) || search == null || x.Initials.Contains(search)).ToList();
            mymodel.Teams = db.Team.Where(x => x.Name.Contains(search) || search == null || x.Initials.Contains(search)).ToList();
            mymodel.TournamentTargs = db.TournamentTag.Where(x => x.Tag.Contains(search));
            mymodel.TeamTags = db.TeamTag.Where(x => x.Tag.Contains(search));

            foreach (TournamentTag tt in mymodel.TournamentTargs)
            {
               mymodel.Tournaments = db.Tournament.Where(x => x.TournamentId == tt.Tournament).ToList();
            }
            
            foreach (TeamTag tt in mymodel.TeamTags)
            {
                mymodel.Teams = db.Team.Where(x => x.TeamId == tt.Team).ToList();
            }

            return View(mymodel);
           
        }

        //Advanced Search
        public ActionResult Details(string name)
        {
            
            var mymodel = new ViewModels.AdvancedSearchViewModel();
            mymodel.Geeks = db.Geek.Where(x => (x.Name.StartsWith(name) || x.Birthdate.Contains(name)) ).ToList();
            mymodel.Tournaments = db.Tournament.Where(x => (x.Name.StartsWith(name))).ToList();
            mymodel.Teams = db.Team.Where(x => x.Name.StartsWith(name) ).ToList();
            mymodel.Games = db.Game.Where(x => x.Name.StartsWith(name)).ToList();
            mymodel.TournamentTags = db.TournamentTag.Where(x => x.Tag.StartsWith(name));
            mymodel.TeamTags = db.TeamTag.Where(x => x.Tag.StartsWith(name));

            foreach (TournamentTag tt in mymodel.TournamentTags)
            {
                mymodel.Tournaments = db.Tournament.Where(x => x.TournamentId == tt.Tournament).ToList();
            }

            foreach (TeamTag tt in mymodel.TeamTags)
            {
                mymodel.Teams = db.Team.Where(x => x.TeamId == tt.Team).ToList();
            }
            return View(mymodel);
        }

        public ActionResult AdvancedSearch()
        {
            ViewBag.Games = db.Game.Where(g => !g.Deleted).ToArray();
            ViewBag.Tournaments = db.Tournament.Where(t => !t.Deleted).ToArray();
            ViewBag.Geeks = db.Geek.Where(g => !g.Deleted).ToArray();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdvancedSearch(AdvancedSearch advancedSearch)
        {
            MultipleSearch searchResult = new MultipleSearch();
            switch(advancedSearch.Search)
            {
                case SearchType.Tournament:
                    searchResult.Tournaments = db.Tournament.Where(t => !t.Deleted);
                    if(!String.IsNullOrWhiteSpace(advancedSearch.Name))
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => t.Name.ToLower().Contains(advancedSearch.Name.ToLower()));
                    if (!String.IsNullOrWhiteSpace(advancedSearch.Initials))
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => t.Initials.ToLower().Contains(advancedSearch.Initials.ToLower()));
                    if (advancedSearch.RegistrationOpen)
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => (t.PeriodRegistration.Start < DateTime.Now) && (t.PeriodRegistration.Ending > DateTime.Now));
                    if (advancedSearch.TournamentOpen)
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => (t.PeriodPlay.Start < DateTime.Now) && (t.PeriodPlay.Ending > DateTime.Now));
                    if (advancedSearch.NumberTeamRegistered > 0)
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => t.Participation.Count == advancedSearch.NumberTeamRegistered);
                    if (advancedSearch.Game > -1)
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => t.Game == advancedSearch.Game);
                    if (!String.IsNullOrWhiteSpace(advancedSearch.Tags))
                    {
                        string[] tags = advancedSearch.Tags.Split(',');
                        searchResult.Tournaments = searchResult.Tournaments.Where(t => tags.All(tag => t.TournamentTag.Any(ttags => !ttags.Deleted && ttags.Tag.ToLower().Contains(tag.ToLower()))));
                    }
                    break;
                case SearchType.Team:
                    searchResult.Teams = db.Team.Where(t => !t.Deleted);
                    if(!String.IsNullOrWhiteSpace(advancedSearch.Name))
                        searchResult.Teams = searchResult.Teams.Where(t => t.Name.ToLower().Contains(advancedSearch.Name.ToLower()));
                    if (!String.IsNullOrWhiteSpace(advancedSearch.Initials))
                        searchResult.Teams = searchResult.Teams.Where(t => t.Initials.ToLower().Contains(advancedSearch.Initials.ToLower()));
                    if (advancedSearch.NumberTournementJoined > 0)
                        searchResult.Teams = searchResult.Teams.Where(t => t.Participation.Count >= advancedSearch.NumberTournementJoined);
                    if (advancedSearch.Game > -1)
                        searchResult.Teams = searchResult.Teams.Where(t => t.Participation.Any(p => p.Tournament1.Game == advancedSearch.Game));
                    if (advancedSearch.Tournament > -1)
                        searchResult.Teams = searchResult.Teams.Where(t => t.Participation.Any(p => p.Tournament == advancedSearch.Tournament));
                    if (advancedSearch.Geek > 0)
                        searchResult.Teams = searchResult.Teams.Where(t => t.TeamGeek.Any(tg => tg.Player == advancedSearch.Geek));
                    if (!String.IsNullOrWhiteSpace(advancedSearch.Tags))
                    {
                        string[] tags = advancedSearch.Tags.Split(',');
                        searchResult.Teams = searchResult.Teams.Where(t => tags.All(tag => t.TeamTag.Any(ttags => ttags.Deleted != true && ttags.Tag.ToLower().Contains(tag.ToLower()))));
                    }
                    break;
                case SearchType.Geek:
                    searchResult.Geeks = db.Geek.Where(t => !t.Deleted);
                    if(!String.IsNullOrWhiteSpace(advancedSearch.Name))
                        searchResult.Geeks = searchResult.Geeks.Where(t => t.Username.ToLower().Contains(advancedSearch.Name.ToLower()));
                    if (advancedSearch.NumberTeamRegistered > 0)
                        searchResult.Geeks = searchResult.Geeks.Where(t => t.TeamGeek.Count >= advancedSearch.NumberTeamRegistered);
                    if (advancedSearch.Game > -1)
                        searchResult.Geeks = searchResult.Geeks.Where(t => t.TeamGeek.Any(tg => tg.Team1.Participation.Any(p => p.Tournament1.Game == advancedSearch.Game)));
                    if (advancedSearch.Tournament > -1)
                        searchResult.Geeks = searchResult.Geeks.Where(t => t.TeamGeek.Any(tg => tg.Team1.Participation.Any(p => p.Tournament == advancedSearch.Tournament)));
                    if (!String.IsNullOrWhiteSpace(advancedSearch.Tags))
                    {
                        string[] tags = advancedSearch.Tags.Split(',');
                        searchResult.Teams = searchResult.Teams.Where(t => tags.All(tag => t.TeamTag.Any(ttags => ttags.Deleted != true && ttags.Tag.ToLower().Contains(tag.ToLower()))));
                    }
                    break;

            }
            return View("Index", searchResult);
        }

        

    }
}
