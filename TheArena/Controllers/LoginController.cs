using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheArena.Models;

namespace TheArena.Controllers
{
    public class LoginController : Controller
    {
        private TheArenaContext context;

        public LoginController()
        {
            context = new TheArenaContext();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Geek geek, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                Geek foundGeek = context.Geek.Where(g => g.Username == geek.Username && g.Password == geek.Password && !g.Deleted).FirstOrDefault();
                if (foundGeek != null)
                {
                    FormsAuthentication.SetAuthCookie(foundGeek.Username, false);
                    if (String.IsNullOrWhiteSpace(returnUrl) || Url.IsLocalUrl(returnUrl))
                        return Redirect("/");
                    else
                        return Redirect(returnUrl);
                }
            }

            ModelState.AddModelError("Geek.Username", "Username et/ou mot de passe incorrect.");
            return View(geek);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}