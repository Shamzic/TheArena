namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Setting")]
    public partial class Setting
    {
        public int SettingId { get; set; }

        public int Geek { get; set; }

        public int Parameter { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        public bool? Deleted { get; set; }

        public virtual Geek Geek1 { get; set; }

        public virtual Parameter Parameter1 { get; set; }
    }
}
