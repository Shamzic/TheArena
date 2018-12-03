using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheArena;
using TheArena.Annotation;
using TheArena.Models;

namespace TheArena.Controllers
{
    [Authorize]
    public class GeeksController : Controller
    {
        private TheArenaContext db = new TheArenaContext();

        // GET: Geeks
        public ActionResult Index()
        {
         return RedirectToAction("Details", new { id = User.Identity.Name });
        }

        // GET: Geeks/Details/5
        public ActionResult Details(string id)
        {
            Geek geek = db.Geek.Where(p => p.Username == id).FirstOrDefault();
            if (geek == null)
            {
                return HttpNotFound();
            }
            return View(geek);
        }

        [EditGeekAuthorized]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geek geek = db.Geek.Where(p => p.Username == id).FirstOrDefault();
            if (geek == null)
            {
                return HttpNotFound();
            }
            return View(geek);
        }

        // POST: Geeks/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [EditGeekAuthorized]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GeekId,Username,Name,Surname,Password,Mail,Birthdate")] Geek geek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(geek);
        }

        // GET: Geeks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geek geek = db.Geek.Where(p => p.Username == id).FirstOrDefault();
            if (geek == null)
            {
                return HttpNotFound();
            }
            return View(geek);
        }

        // POST: Geeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Geek geek = db.Geek.Where(p => p.Username == id).FirstOrDefault();
            geek.Deleted = true;
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
