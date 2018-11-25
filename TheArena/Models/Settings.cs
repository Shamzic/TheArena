namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settings
    {
        public int SettingsId { get; set; }

        public int Geek { get; set; }

        public int Setting { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek1 { get; set; }

        public virtual Setting Setting1 { get; set; }
    }
}
