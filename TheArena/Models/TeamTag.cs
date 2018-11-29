namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamTag")]
    public partial class TeamTag
    {
        [Key]
        public int TagId { get; set; }

        public int Team { get; set; }

        [StringLength(255)]
        public string Tag { get; set; }

        public bool? Deleted { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
