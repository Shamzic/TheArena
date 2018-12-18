using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheArena.BLL;
using TheArena.Models;
using TheArena.ViewModels;


namespace TheArena.Controllers
{
    public class SearchController : Controller
    {
        private TheArenaContext db = new TheArenaContext();
        private SearchBLL bll = new SearchBLL();
        

        // GET: Search
        public ActionResult Index(String search)
        {//
            

            return View(bll.SimpleSearch(search));
           
        }

        //Advanced Search
        public ActionResult Details(string name)
        {
            
            return View(bll.SimpleSearch(name));
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
            
            return View("Index", bll.ComplexSearch(advancedSearch));
        }

        
    }
}
