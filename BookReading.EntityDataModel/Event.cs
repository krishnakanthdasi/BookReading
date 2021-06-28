namespace BookReading.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            Invitations = new HashSet<Invitation>();
        }

        public int EventId { get; set; }

        [Required(ErrorMessage = "Please Enter Title")]
        public string EventName { get; set; }

         
        public string EventDescription { get; set; }

        public string EventOtherDetails { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]
        public string EventLocation { get; set; }
        
        public int EventDuration { get; set; }
        
        public int EventType { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]

        public DateTime EventDate { get; set; }

        
        public string EventStartTime { get; set; }

        public int EventActive { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
