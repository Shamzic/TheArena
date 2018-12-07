using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheArena.Models;
namespace TheArena.ViewModels
{
    public class MultipleSearch
    {
        //
        public IEnumerable<Game> Games{ get; set; }
        public IEnumerable<Geek> Geeks { get; set; }
        public IEnumerable<Tournament> Tournaments { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<TeamTag> TeamTags { get; set; }
        public IEnumerable<TournamentTag> TournamentTargs { get; set; }
    }
}