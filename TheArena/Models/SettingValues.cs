namespace TheArena.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SettingValues
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SettingValues()
        {
            Settings = new HashSet<Settings>();
        }

        public int SettingValuesId { get; set; }

        public int Setting { get; set; }

        [StringLength(255)]
        public string Value { get; set; }

        public bool Preselected { get; set; }

        public bool Deleted { get; set; }

        public virtual Setting Setting1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Settings> Settings { get; set; }
    }
}
