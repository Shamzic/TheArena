namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Division")]
    public partial class Division
    {
        public int DivisionId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int Game { get; set; }

        public bool Deleted { get; set; }

        public virtual Game Game1 { get; set; }
    }
}
