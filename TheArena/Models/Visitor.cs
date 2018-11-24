namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        [StringLength(255)]
        public string Ip { get; set; }

        public bool? Deleted { get; set; }
    }
}
