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
            if (User.Identity.IsAuthenticated)
                return Redirect("/");
            return View();
        }

        [HttpPost]
        public ActionResult Index(Geek geek, string returnUrl)
        {
            if (!String.IsNullOrWhiteSpace(geek.Username) && !String.IsNullOrWhiteSpace(geek.Password))
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

            ModelState.AddModelError("Username", "Username et/ou mot de passe incorrect.");
            return View(geek);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "GeekId,Username,Name,Surname,Password,Mail,Birthdate,Deleted")] Geek geek)
        {
            geek.Deleted = false;
            if (ModelState.IsValid)
            {
                context.Geek.Add(geek);
                context.SaveChanges();
                // On rajoute les valeurs par défaut au moment de l'inscription
                    
                context.Settings.AddRange(
                    context.Setting.Where(s => !s.Deleted)
                    .Select(s => new {
                        SettingValue = s.SettingValues.Where(
                            sv => !sv.Deleted && sv.Preselected
                        ).FirstOrDefault().SettingValuesId,
                    }).ToArray()
                    .Select(s => new Settings()
                    {
                        Geek = geek.GeekId,
                        SettingValue = s.SettingValue,
                        Deleted = false,
                    })
                );
                context.SaveChanges();
                return Index(geek, null);
            }
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