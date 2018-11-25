namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowPlayer")]
    public partial class FollowPlayer
    {
        public int FollowPlayerId { get; set; }

        public int Geek { get; set; }

        public int Player { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek1 { get; set; }

        public virtual Geek Geek2 { get; set; }
    }
}
