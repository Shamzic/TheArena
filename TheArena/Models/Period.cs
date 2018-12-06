namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TheArena.Attributes;

    [Table("Period")]
    public partial class Period
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Period()
        {
            Ban = new HashSet<Ban>();
            Tournament = new HashSet<Tournament>();
            Tournament1 = new HashSet<Tournament>();
            Versus = new HashSet<Versus>();
        }

        public Period(DateTime PeriodStart, DateTime PeriodEnd) 
        {
        
            Start = PeriodStart;
            Ending = PeriodEnd;

            Ban = new HashSet<Ban>();
            Tournament = new HashSet<Tournament>();
            Tournament1 = new HashSet<Tournament>();
            Versus = new HashSet<Versus>();    
        }

        public int PeriodId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [PeriodeAttributes(otherPropertyName = "Start", ErrorMessage = "La date de fin doit etre superieure a la date de debut")]
        public DateTime Ending { get; set; }

        public bool Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ban> Ban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tournament> Tournament { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tournament> Tournament1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Versus> Versus { get; set; }

    }
}
