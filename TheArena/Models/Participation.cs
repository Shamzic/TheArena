namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Participation")]
    public partial class Participation
    {
        public int ParticipationId { get; set; }

        public int? Place { get; set; }

        public bool? Qualified { get; set; }

        public int Team { get; set; }

        public int Tournament { get; set; }

        public bool? Deleted { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Tournament Tournament1 { get; set; }
    }
}
