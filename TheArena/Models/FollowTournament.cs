namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowTournament")]
    public partial class FollowTournament
    {
        public int FollowTournamentId { get; set; }

        public int Geek { get; set; }

        public int Tournament { get; set; }

        public bool Deleted { get; set; }

        public virtual Tournament Tournament1 { get; set; }

        public virtual Geek Geek1 { get; set; }
    }
}
