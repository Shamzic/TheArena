namespace TheArena.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    using TheArena.Attributes;

    [Table("Tournament")]
    public partial class Tournament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tournament()
        {
            FollowTournament = new HashSet<FollowTournament>();
            Participation = new HashSet<Participation>();
            TournamentLog = new HashSet<TournamentLog>();
            TournamentTag = new HashSet<TournamentTag>();
            Versus = new HashSet<Versus>();
        }

        public int TournamentId { get; set; }

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string Initials { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Rules { get; set; }

        public int? Slots { get; set; }

        public int? PlayerNumber { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string Tags { get; set; }

        [JsonIgnore]
        public int RegisteringPeriod { get; set; }

        [JsonIgnore]
        public int PlayingPeriod { get; set; }

        [JsonIgnore]
        public int Game { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }
        [JsonIgnore]
        public int Organiser { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowTournament> FollowTournament { get; set; }

        public virtual Game Game1 { get; set; }

        [JsonIgnore]
        public virtual Geek Geek { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participation> Participation { get; set; }

        public virtual Period PeriodRegistration { get; set; }

        public virtual Period PeriodPlay { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TournamentLog> TournamentLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TournamentTag> TournamentTag { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Versus> Versus { get; set; }

    }
}
