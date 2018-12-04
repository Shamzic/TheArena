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
    public class TournamentController : Controller
    {
        private TheArenaContext db = new TheArenaContext();

        // GET: Tournament
        // GET: Tournament
        public ActionResult Index()
        {
            var tournament = db.Tournament.Where(t => t.Deleted == false).Include(t => t.Game1).Include(t => t.Geek).Include(t => t.PeriodRegistration).Include(t => t.PeriodPlay);
            return View(tournament.ToList());
        }

        // GET: Tournament/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            Geek user = db.Geek.Where(g => g.Username == User.Identity.Name && !g.Deleted).FirstOrDefault();
            TournamentDetailViewModel viewModel = new TournamentDetailViewModel
            {
                tournament = tournament,
                geek = user,
            };
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Tournament/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Game = new SelectList(db.Game, "GameId", "Name");
                ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username");
                ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId");
                ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId");
                return View();
            }
            else
            {
                ViewBag.Message = "Vous devez être connecté pour créer un tournoi";
                var tournament = db.Tournament.Where(t => t.Deleted == false).Include(t => t.Game1).Include(t => t.Geek).Include(t => t.PeriodRegistration).Include(t => t.PeriodPlay);
                return View("Index", tournament.ToList());
            }
        }

        // POST: Tournament/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentId,Initials,Name,Rules,Slots,PlayerNumber,Tags,RegisteringPeriod,PlayingPeriod,Game,Deleted,Organiser")] Tournament tournament, DateTime registeringPeriodStart, DateTime registeringPeriodEnd, DateTime playingPeriodStart, DateTime playingPeriodEnd)
        {
            tournament.Deleted = false;
            Geek organiser = db.Geek.Where(g => g.Username == User.Identity.Name && !g.Deleted).FirstOrDefault();
            Period playingPeriod = new Period(playingPeriodStart, playingPeriodEnd);
            Period registeringPeriod = new Period(registeringPeriodStart, registeringPeriodEnd);
            tournament.Organiser = organiser.GeekId;
            tournament.PeriodRegistration = registeringPeriod;
            tournament.PeriodPlay = playingPeriod;
            RolesGeek role = new RolesGeek
            {
                Deleted = false,
                Role = 5,
                Geek = organiser.GeekId
            }
            ;
            if (ModelState.IsValid)
            {
                db.RolesGeek.Add(role);
                db.Tournament.Add(tournament);
                db.TournamentLog.Add(new TournamentLog
                {
                    Deleted=false,
                    Entry = "Le tournoi a été créé avec succès.",
                    Time = (int) new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                    Tournament = tournament.TournamentId
                });
                db.SaveChanges();
                return RedirectToAction("Details", new { id = tournament.TournamentId });
            }
            else
            {
                ViewBag.Message = "Erreur lors de la création du tournoi";
                ViewBag.Game = new SelectList(db.Game, "GameId", "Name", tournament.Game);
                ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username", tournament.Organiser);
                ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.RegisteringPeriod);
                ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.PlayingPeriod);
                return View(tournament);
            }
           
        }

        // GET: Tournament/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            Geek organiser = db.Geek.Where(g => g.Username == User.Identity.Name && !g.Deleted).FirstOrDefault();
            if (organiser.GeekId == tournament.Organiser)
            {
                return View(tournament);
            }
            else
            {
                ViewBag.Message = "Seul le créateur du tournoi peut le modifier";
                var tournaments = db.Tournament.Where(t => t.Deleted == false).Include(t => t.Game1).Include(t => t.Geek).Include(t => t.PeriodRegistration).Include(t => t.PeriodPlay);
                return View("Index", tournaments.ToList());
            }
        }

        // POST: Tournament/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentId,Initials,Name,Rules,Slots,PlayerNumber,Tags,RegisteringPeriod,PlayingPeriod,Game,Deleted,Organiser")] Tournament tournament, DateTime PeriodRegistrationStart, DateTime PeriodRegistrationEnd, DateTime PeriodPlayStart, DateTime PeriodPlayEnd)
        {
            if (ModelState.IsValid)
            {
                tournament.PeriodRegistration = db.Period.Find(tournament.RegisteringPeriod);
                tournament.PeriodPlay = db.Period.Find(tournament.PlayingPeriod);
                tournament.PeriodPlay.Start = PeriodPlayStart;
                tournament.PeriodPlay.Ending = PeriodPlayEnd;
                tournament.PeriodRegistration.Start = PeriodRegistrationStart;
                tournament.PeriodRegistration.Ending = PeriodRegistrationEnd;
                TournamentLog log = new TournamentLog
                {
                    Deleted = false,
                    Entry = "Le tournoi a été modifié.",
                    Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                    Tournament = tournament.TournamentId
                };
                db.TournamentLog.Add(log);
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = tournament.TournamentId });
            }
            ViewBag.Game = new SelectList(db.Game, "GameId", "Name", tournament.Game);
            ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username", tournament.Organiser);
            ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.RegisteringPeriod);
            ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.PlayingPeriod);
            return View(tournament);
        }

        // GET: Tournament/Delete/5
        public ActionResult Delete(int? id)
        {
            if(User.Identity.IsAuthenticated && User.Identity.Name == db.Tournament.Find(id).Geek.Name) {
                Tournament tournament = db.Tournament.Find(id);
                tournament.Deleted = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Vous n'avez pas l'autorisation de supprimer ce tournoi";
                var tournament = db.Tournament.Where(t => t.Deleted == false).Include(t => t.Game1).Include(t => t.Geek).Include(t => t.PeriodRegistration).Include(t => t.PeriodPlay);
                return View("Index", tournament.ToList());
            }
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // POST: Tournament/Details/id/Participate
        [HttpPost, ActionName("Participate")]
        [ValidateAntiForgeryToken]
        public ActionResult Participate([Bind(Include ="TeamID")]Team team, [Bind(Include = "TournamentId")]Tournament tournament)
        {
            Participation participation = db.Participation.Where(p => p.Team == team.TeamId && p.Tournament== tournament.TournamentId).FirstOrDefault();
            if (participation != null)
            {
                db.TournamentLog.Add(new TournamentLog
                {
                    Deleted = false,
                    Entry = "L'équipe " + participation.Team1.Name + " s'est inscrit au tournoi.",
                    Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                    Tournament = tournament.TournamentId
                });
                participation.Deleted = false;
                db.SaveChanges();
            }
            else{
                participation = new Participation();
                participation.Deleted = false;
                participation.Team = team.TeamId;
                participation.Tournament = tournament.TournamentId;
                participation.Qualified = true;
                if (ModelState.IsValid)
                {
                     TournamentLog newLog = new TournamentLog
                    {
                        Deleted = false,
                        Entry = "L'équipe " + participation.Team1.Name + " s'est inscrit au tournoi.",
                        Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                        Tournament = tournament.TournamentId
                     };
                    db.TournamentLog.Add(newLog);
                    db.Participation.Add(participation);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Details", new { id = tournament.TournamentId });
        }

        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult Abandonner([Bind(Include = "TeamID")]Team team, [Bind(Include = "TournamentId")]Tournament tournament)
        {
            Participation participation = db.Participation.Where(p => p.Team == team.TeamId && p.Tournament == tournament.TournamentId).FirstOrDefault();
            if (participation != null)
            {
                TournamentLog log = new TournamentLog
                {
                    Deleted = false,
                    Entry = "L'équipe " + participation.Team1.Name + " a été retiré.",
                    Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                    Tournament = tournament.TournamentId
                };
                db.TournamentLog.Add(log);
                participation.Deleted = true;
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { id = tournament.TournamentId });
        }

        [HttpPost, ActionName("DeleteTag")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTag([Bind(Include = "TagId")]TournamentTag tournamentTag, [Bind(Include = "TournamentId")]Tournament tournament)
        {
            TournamentTag tag = db.TournamentTag.Find(tournamentTag.TagId);
            if (tag != null)
            {
            TournamentLog log = new TournamentLog
            {
                Deleted = false,
                Entry = "Le tag " + tag.Tag + " a été retiré.",
                Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Tournament = tournament.TournamentId
            };
            db.TournamentLog.Add(log);
            tag.Deleted = true;
            db.SaveChanges();
        }
            return RedirectToAction("Details", new { id = tournament.TournamentId });
        }

        [HttpPost, ActionName("AddTag")]
        [ValidateAntiForgeryToken]
        public ActionResult AddTag([Bind(Include = "Tag")]TournamentTag tournamentTag, [Bind(Include = "TournamentId")]Tournament tournament)
        {
            tournamentTag.Deleted = false;
            tournamentTag.Tournament = tournament.TournamentId;
            if (ModelState.IsValid)
            {
                TournamentLog log = new TournamentLog
                {
                    Deleted = false,
                    Entry = "Le tag " + tournamentTag.Tag + " a été ajouté.",
                    Time = (int)new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                    Tournament = tournament.TournamentId
                };
                db.TournamentLog.Add(log);
            }
            db.TournamentTag.Add(tournamentTag);
            db.SaveChanges();    
        return RedirectToAction("Details", new { id = tournament.TournamentId });
        }

    }
}