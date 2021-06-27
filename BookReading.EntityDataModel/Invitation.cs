namespace BookReading.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invitation
    {
        public int Id { get; set; }

        public int InvitationActive { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public virtual Event Event { get; set; }
    }
}
