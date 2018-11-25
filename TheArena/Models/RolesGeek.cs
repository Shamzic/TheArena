namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RolesGeek")]
    public partial class RolesGeek
    {
        public int RolesGeekId { get; set; }

        public int Role { get; set; }

        public int Geek { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek1 { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
