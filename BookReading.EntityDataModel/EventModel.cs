using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.EntityDataModel
{
    [NotMapped]
    public class EventModel : Event
    {

        public String userInvitation { get; set; }
    }
}
