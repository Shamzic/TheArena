using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheArena;
using TheArena.Models;

namespace TheArena.Controllers
{
    public class HomeController : Controller
    {

        private TheArenaContext db = new TheArenaContext();

        public ActionResult Index()
        {
            Tournament[] lastUpdated = db.TournamentLog.Where(r => r.Deleted != true).GroupBy(x => x.Tournament).Select(x => x.FirstOrDefault()).Take(5).Select(t => t.Tournament1).ToArray();
            
            return View(lastUpdated);
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}