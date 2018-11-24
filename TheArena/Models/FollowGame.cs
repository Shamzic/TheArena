namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowGame")]
    public partial class FollowGame
    {
        public int FollowGameId { get; set; }

        public int Geek { get; set; }

        public int Game { get; set; }

        public bool? Deleted { get; set; }

        public virtual Game Game1 { get; set; }

        public virtual Geek Geek1 { get; set; }
    }
}
