namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        public int ScoreId { get; set; }

        public int Result { get; set; }

        public int ScoreType { get; set; }

        public int? Winner { get; set; }

        public int? Loser { get; set; }

        public bool? Deleted { get; set; }

        public virtual ScoreType ScoreType1 { get; set; }
    }
}
