using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheArena.ViewModels
{
    public class TeamViewModel
    {
        public Models.Team team { get; set; }
        public List<Models.Geek> geekTeamList { get; set; }
    }
}