namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Versus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Versus()
        {
            Round = new HashSet<Round>();
        }

        public int VersusId { get; set; }

        public int? Team1 { get; set; }

        public int? Team2 { get; set; }

        public int VersusPeriod { get; set; }

        public int Result { get; set; }

        public int Tournament { get; set; }

        public bool? Deleted { get; set; }

        public virtual Period Period { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Round> Round { get; set; }

        public virtual Team Team { get; set; }

        public virtual Team Team3 { get; set; }

        public virtual Tournament Tournament1 { get; set; }
    }
}
