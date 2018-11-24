namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stats
    {
        [Key]
        public int StatisticsId { get; set; }

        public int Game { get; set; }

        public int Team { get; set; }

        public int Player { get; set; }

        public int? WinNumber { get; set; }

        public int? LoseNumber { get; set; }

        public int? LifetimeScore { get; set; }

        public bool? Deleted { get; set; }

        public virtual Game Game1 { get; set; }

        public virtual Geek Geek { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
