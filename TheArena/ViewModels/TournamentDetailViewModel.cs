using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheArena.ViewModels
{
    public class TournamentDetailViewModel
    {
        public Models.Tournament tournament { get; set; }
        public Models.Geek geek { get; set; }
    }
}