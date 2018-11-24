namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ranking")]
    public partial class Ranking
    {
        public int RankingId { get; set; }

        public int? Standing { get; set; }

        public int Game { get; set; }

        public int? Division { get; set; }

        public int Team { get; set; }

        public bool? Deleted { get; set; }

        public virtual Game Game1 { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
