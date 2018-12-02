﻿using System;
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
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
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
            Team team = await db.Team.FindAsync(id);
            db.Team.Remove(team);
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

        // GET: Teams/Inscription/5
        public async Task<ActionResult> Inscription(int? id)
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

        //// POST: Teams/Inscription/5
        [HttpPost, ActionName("Inscription")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InscriptionConfirmed(int id)
        {
            Team team = await db.Team.FindAsync(id);
            //db.Team.Remove(team);

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
