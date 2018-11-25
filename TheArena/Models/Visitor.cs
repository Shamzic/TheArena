namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        public int VisitorId { get; set; }

        [Required]
        [StringLength(255)]
        public string Ip { get; set; }

        public bool Deleted { get; set; }
    }
}
