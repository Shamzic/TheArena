namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeamGeek")]
    public partial class TeamGeek
    {
        public int TeamGeekId { get; set; }

        public int Player { get; set; }

        public int Team { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
