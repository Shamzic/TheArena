using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheArena.Models;
namespace TheArena.ViewModels
{
    public class AdvancedSearchViewModel
    {
        public IEnumerable<Game> gamess { get; set; }
        public IEnumerable<Geek> geekss { get; set; }
        public IEnumerable<Tournament> tournamentss { get; set; }
        public IEnumerable<Team> teamss { get; set; }
        public IEnumerable<TeamTag> teamTagss { get; set; }
        public IEnumerable<TournamentTag> tournamentTagss { get; set; }
    }
}