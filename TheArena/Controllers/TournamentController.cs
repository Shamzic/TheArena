using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using TheArena.Models;

namespace TheArena.Controllers
{
    public class TournamentController : Controller
    {
        private TheArenaContext db = new TheArenaContext();

        // GET: Tournament
        public ActionResult Index()
        {
            var tournament = db.Tournament.Where(t => t.Deleted == false).Include(t => t.Game1).Include(t => t.Geek).Include(t => t.Period).Include(t => t.Period1);
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
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournament/Create
        public ActionResult Create()
        {
            ViewBag.Game = new SelectList(db.Game, "GameId", "Name");
            ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username");
            ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId");
            ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId");
            return View();
        }

        // POST: Tournament/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TournamentId,Initials,Name,Rules,Slots,PlayerNumber,Tags,RegisteringPeriod,PlayingPeriod,Game,Deleted,Organiser")] Tournament tournament)
        {
            tournament.Deleted = false;
            Geek organiser = db.Geek.Where(g => g.Username == User.Identity.Name && !g.Deleted).FirstOrDefault();
            tournament.Organiser = organiser.GeekId;
            if (ModelState.IsValid)
            {
                db.Tournament.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Game = new SelectList(db.Game, "GameId", "Name", tournament.Game);
            ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username", tournament.Organiser);
            ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.RegisteringPeriod);
            ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.PlayingPeriod);
            return View(tournament);
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
            ViewBag.Game = new SelectList(db.Game, "GameId", "Name", tournament.Game);
            ViewBag.Organiser = new SelectList(db.Geek, "GeekId", "Username", tournament.Organiser);
            ViewBag.RegisteringPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.RegisteringPeriod);
            ViewBag.PlayingPeriod = new SelectList(db.Period, "PeriodId", "PeriodId", tournament.PlayingPeriod);
            return View(tournament);
        }

        // POST: Tournament/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TournamentId,Initials,Name,Rules,Slots,PlayerNumber,Tags,RegisteringPeriod,PlayingPeriod,Game,Deleted,Organiser")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournament.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournament.Find(id);
            tournament.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
