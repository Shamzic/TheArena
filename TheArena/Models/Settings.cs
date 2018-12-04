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

        public int SettingValue { get; set; }

        public bool Deleted { get; set; }

        public virtual Geek Geek1 { get; set; }

        public virtual SettingValues SettingValues { get; set; }
    }
}
