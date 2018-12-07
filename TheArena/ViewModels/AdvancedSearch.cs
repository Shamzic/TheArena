using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheArena.Models;

namespace TheArena.ViewModels
{
    public class AdvancedSearch
    {
        public SearchType Search { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int Game { get; set; }
        public bool TournamentOpen { get; set; }
        public bool RegistrationOpen { get; set; }
        public int NumberTeamRegistered { get; set; }
        public string Tags { get; set; }
        public int Tournament { get; set; }
        public int Geek { get; set; }
        public int NumberTournementJoined { get; set; }
    }
}