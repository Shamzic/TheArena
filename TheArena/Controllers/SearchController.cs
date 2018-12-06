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


        // GET: SearchGeek
        public ActionResult Index(String search)
        {//
            var mymodel = new ViewModels.MultipleSearch();
            mymodel.gamess = db.Game.Where(x => x.Name.Contains(search) || search == null ).ToList();
            mymodel.geekss = db.Geek.Where(x => x.Name.Contains(search) || search == null || x.Username.Contains(search) || x.Surname.Contains(search)).ToList();
            mymodel.tournamentss = db.Tournament.Where(x => x.Name.Contains(search) || search == null || x.Tags.Contains(search) || x.Initials.Contains(search) ).ToList();
            mymodel.teamss = db.Team.Where(x => x.Name.Contains(search) || x.Tags.Contains(search) || search == null || x.Initials.Contains(search));
            return View(mymodel);
            //return View(db.Geek.Where(x => x.Name.Contains(search) || search==null).ToList());
        }


    }
}
