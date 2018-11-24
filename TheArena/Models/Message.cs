namespace TheArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int MessageId { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public int Time { get; set; }

        public int Sender { get; set; }

        public int Receiver { get; set; }

        public bool? Deleted { get; set; }

        public virtual Geek Geek { get; set; }

        public virtual Geek Geek1 { get; set; }
    }
}
