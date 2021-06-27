using BookReading.Business;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.BusinessFacades
{
    public class EventFacade
    {
        EventBusiness eventBusiness;
        public EventFacade()
        {
            eventBusiness = new EventBusiness();
        }

        public IEnumerable<Event> GetPublicEvents()
        {
            return eventBusiness.GetPublicEvent();
        }

    }
}
