namespace TheArena.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TournamentTag")]
    public partial class TournamentTag
    {
        [Key]
        public int TagId { get; set; }

        public int Tournament { get; set; }

        [StringLength(255)]
        public string Tag { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual Tournament Tournament1 { get; set; }
    }
}
