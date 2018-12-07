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
            mymodel.gamess = db.Game.Where(x => x.Name.Contains(search) || search == null).ToList();
            mymodel.geekss = db.Geek.Where(x => x.Name.Contains(search) || search == null || x.Username.Contains(search) || x.Surname.Contains(search)).ToList();
            mymodel.tournamentss = db.Tournament.Where(x => x.Name.Contains(search) || search == null || x.Initials.Contains(search)).ToList();
            mymodel.teamss = db.Team.Where(x => x.Name.Contains(search) || search == null || x.Initials.Contains(search)).ToList();
            mymodel.tournamentTagss = db.TournamentTag.Where(x => x.Tag.Contains(search));
            mymodel.teamTagss = db.TeamTag.Where(x => x.Tag.Contains(search));

            foreach (TournamentTag tt in mymodel.tournamentTagss)
            {
               mymodel.tournamentss = db.Tournament.Where(x => x.TournamentId == tt.Tournament).ToList();
            }
            
            foreach (TeamTag tt in mymodel.teamTagss)
            {
                mymodel.teamss = db.Team.Where(x => x.TeamId == tt.Team).ToList();
            }

            return View(mymodel);
           
        }

        //Advanced Search
        public ActionResult Details(string name)
        {
            
            var mymodel = new ViewModels.AdvancedSearchViewModel();
            mymodel.geekss = db.Geek.Where(x => (x.Name.StartsWith(name) || x.Birthdate.Contains(name)) ).ToList();
            mymodel.tournamentss = db.Tournament.Where(x => (x.Name.StartsWith(name))).ToList();
            mymodel.teamss = db.Team.Where(x => x.Name.StartsWith(name) ).ToList();
            mymodel.gamess = db.Game.Where(x => x.Name.StartsWith(name)).ToList();
            mymodel.tournamentTagss = db.TournamentTag.Where(x => x.Tag.StartsWith(name));
            mymodel.teamTagss = db.TeamTag.Where(x => x.Tag.StartsWith(name));

            foreach (TournamentTag tt in mymodel.tournamentTagss)
            {
                mymodel.tournamentss = db.Tournament.Where(x => x.TournamentId == tt.Tournament).ToList();
            }

            foreach (TeamTag tt in mymodel.teamTagss)
            {
                mymodel.teamss = db.Team.Where(x => x.TeamId == tt.Team).ToList();
            }
            return View(mymodel);
        }

        

    }
}
