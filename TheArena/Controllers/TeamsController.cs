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
using TheArena.ViewModels;

namespace TheArena.Controllers
{
    public class TeamsController : Controller
    {
        private TheArenaContext db = new TheArenaContext();

        // GET: Teams
        public async Task<ActionResult> Index()
        {
            var team = db.Team.Include(t => t.Geek);
            return View(await team.ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            List<TeamGeek> teamList = db.TeamGeek.Where(o => o.Team == id).ToList();
            List<Geek> teamGeekList = new List<Geek>();
            foreach (var t in teamList)
            {
                teamGeekList.Add(t.Geek);
            }
            TeamViewModel viewModel = new TeamViewModel
            {
                team = team,
                geekTeamList = teamGeekList,
                teamList = teamList,

            };
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            ViewBag.Captain = new SelectList(db.Geek, "GeekId", "Username");
            return View();
        }

        // POST: Teams/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeamId,Initials,Name,Tags,Captain,Deleted")] Team team)
        {
            if (ModelState.IsValid)
            {
                Geek capitaine = db.Geek.Where(g => g.Username == User.Identity.Name).FirstOrDefault();
                team.Captain = capitaine.GeekId;
                TeamGeek tg = new TeamGeek();
                tg.Player = capitaine.GeekId;
                tg.Team = team.TeamId;
                db.TeamGeek.Add(tg);
                db.Team.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Captain = new SelectList(db.Geek, "GeekId", "Username", team.Captain);
            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.Captain = new SelectList(db.Geek, "GeekId", "Username", team.Captain);
            return View(team);
        }

        // POST: Teams/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeamId,Initials,Name,Tags,Captain,Deleted")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Captain = new SelectList(db.Geek, "GeekId", "Username", team.Captain);
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Team.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {

            List<TeamGeek> teamgeek = db.TeamGeek.Where( t => t.Team == id).ToList();
            foreach(TeamGeek tg in teamgeek)
            {
                //db.TeamGeek.Remove(tg);
                tg.Deleted = true;
            }

            Team team = await db.Team.FindAsync(id);
            // db.Team.Remove(team);
            team.Deleted = true;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Teams/Delete/5
        public async Task<ActionResult> DeleteM(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geek g = await db.Geek.FindAsync(id);
            if (g == null)
            {
                return HttpNotFound();
            }
            return View(g);
        }
        [HttpPost, ActionName("DeleteM")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteMember(int id)
        {
            TeamGeek tgsuppr = db.TeamGeek.Where(tg => tg.Player == id).FirstOrDefault();
            tgsuppr.Deleted = true;
            await db.SaveChangesAsync();
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
