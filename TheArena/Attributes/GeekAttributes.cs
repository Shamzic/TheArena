using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheArena.Models;

namespace TheArena.Annotation
{
    public class EditGeekAuthorized: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            using (TheArenaContext context = new TheArenaContext())
            {
                var id = (httpContext.Request.RequestContext.RouteData.Values["id"] as string)?? httpContext.Request.Form["Username"];
                Geek loggedGeek = context.Geek.Where(g => g.Username == httpContext.User.Identity.Name).FirstOrDefault();
                if (id != loggedGeek.Username && !loggedGeek.RolesGeek.Any(r => r.Roles.Name == "Admin" && r.Roles.Deleted != true))
                    return false;
                else
                    return true;
            }
        }
    }
}