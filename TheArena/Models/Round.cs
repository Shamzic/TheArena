namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Round")]
    public partial class Round
    {
        public int RoundId { get; set; }

        public int? Number { get; set; }

        public int Versus { get; set; }

        public int? Result { get; set; }

        public bool? Deleted { get; set; }

        public virtual Result Result1 { get; set; }

        public virtual Versus Versus1 { get; set; }
    }
}
