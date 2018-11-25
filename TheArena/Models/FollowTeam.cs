namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowTeam")]
    public partial class FollowTeam
    {
        public int FollowTeamId { get; set; }

        public int Geek { get; set; }

        public int Team { get; set; }

        public bool Deleted { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Geek Geek1 { get; set; }
    }
}
