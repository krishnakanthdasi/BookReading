namespace BookReading.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        public string UserComment { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }
    }
}
