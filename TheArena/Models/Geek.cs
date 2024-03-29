namespace TheArena.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TheArena.Annotation;

    [Table("Geek")]
    public partial class Geek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Geek()
        {
            Ban = new HashSet<Ban>();
            FollowGame = new HashSet<FollowGame>();
            FollowPlayer = new HashSet<FollowPlayer>();
            FollowPlayer1 = new HashSet<FollowPlayer>();
            FollowTeam = new HashSet<FollowTeam>();
            FollowTournament = new HashSet<FollowTournament>();
            Message = new HashSet<Message>();
            Message1 = new HashSet<Message>();
            RolesGeek = new HashSet<RolesGeek>();
            Settings = new HashSet<Settings>();
            Stats = new HashSet<Stats>();
            Team = new HashSet<Team>();
            TeamGeek = new HashSet<TeamGeek>();
            Tournament = new HashSet<Tournament>();
        }

        public int GeekId { get; set; }

        [Required]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Surname { get; set; }

        [JsonIgnore]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        [Index(IsUnique = true)]
        [RegularExpression(@"^\w+@[\w]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Merci de v�rfier le format de l'adresse mail.")]
        public string Mail { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^(?:19|20)\d{2}-[01]\d-[0-3]\d$", ErrorMessage = "Merci d'entrer une date correcte.")]
        [DateCheck]
        public string Birthdate { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ban> Ban { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowGame> FollowGame { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowPlayer> FollowPlayer { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowPlayer> FollowPlayer1 { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowTeam> FollowTeam { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FollowTournament> FollowTournament { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Message1 { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolesGeek> RolesGeek { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Settings> Settings { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stats> Stats { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Team { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGeek> TeamGeek { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tournament> Tournament { get; set; }
    }
}
