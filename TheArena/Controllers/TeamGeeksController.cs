using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheArena.Models;

namespace TheArena.Controllers
{
    public class TeamGeeksController : Controller
    {
        private TheArenaContext db = new TheArenaContext();

        // GET: TeamGeeks
        public async Task<ActionResult> Index()
        {
            var teamGeek = db.TeamGeek.Include(t => t.Geek).Include(t => t.Team1);
            return View(await teamGeek.ToListAsync());
        }

        // GET: TeamGeeks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamGeek teamGeek = await db.TeamGeek.FindAsync(id);
            if (teamGeek == null)
            {
                return HttpNotFound();
            }
            return View(teamGeek);
        }

        // GET: TeamGeeks/Create
        public ActionResult Create()
        {
            ViewBag.Player = new SelectList(db.Geek, "GeekId", "Username");
            ViewBag.Team = new SelectList(db.Team, "TeamId", "Initials");
            return View();
        }

        // POST: TeamGeeks/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeamGeekId,Player,Team,Deleted")] TeamGeek teamGeek, int teamID)
        {
            if (ModelState.IsValid)
            {
                //teamGeek.Player = 2;
                Geek geek = db.Geek.Where(g => g.Username == User.Identity.Name).FirstOrDefault();
                teamGeek.Player = geek.GeekId;
                teamGeek.Team = teamID;
                db.TeamGeek.Add(teamGeek);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Teams/Details/"+ teamID);
            }
            
            //ViewBag.Player = new SelectList(db.Geek, "GeekId", "Username", User.Identity);
            //ViewBag.Team = new SelectList(db.Team, "TeamId", "Initials", teamGeek.Team);
            return View(teamGeek);
        }



        // GET: TeamGeeks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamGeek teamGeek = await db.TeamGeek.FindAsync(id);
            if (teamGeek == null)
            {
                return HttpNotFound();
            }
            ViewBag.Player = new SelectList(db.Geek, "GeekId", "Username", teamGeek.Player);
            ViewBag.Team = new SelectList(db.Team, "TeamId", "Initials", teamGeek.Team);
            return View(teamGeek);
        }

        // POST: TeamGeeks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeamGeekId,Player,Team,Deleted")] TeamGeek teamGeek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamGeek).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Player = new SelectList(db.Geek, "GeekId", "Username", teamGeek.Player);
            ViewBag.Team = new SelectList(db.Team, "TeamId", "Initials", teamGeek.Team);
            return View(teamGeek);
        }
       
        // GET: TeamGeeks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamGeek teamGeek = await db.TeamGeek.FindAsync(id);
            if (teamGeek == null)
            {
                return HttpNotFound();
            }
            return View(teamGeek);
        }

        // POST: TeamGeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TeamGeek teamGeek = await db.TeamGeek.FindAsync(id);
            teamGeek.Deleted = true;
            //db.TeamGeek.Remove(teamGeek);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Teams/Details/"+teamGeek.Team);
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
