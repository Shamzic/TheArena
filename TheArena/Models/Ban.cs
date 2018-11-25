namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ban")]
    public partial class Ban
    {
        public int BanId { get; set; }

        [StringLength(255)]
        public string Commentary { get; set; }

        public int BannedGeek { get; set; }

        public int BanPeriod { get; set; }

        public int BanReason { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Period Period { get; set; }
    }
}
