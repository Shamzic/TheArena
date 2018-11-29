namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TournamentLog")]
    public partial class TournamentLog
    {
        [Key]
        public int EntryId { get; set; }

        public int Tournament { get; set; }

        [StringLength(255)]
        public string Entry { get; set; }

        public int? Time { get; set; }

        public bool? Deleted { get; set; }

        public virtual Tournament Tournament1 { get; set; }
    }
}
