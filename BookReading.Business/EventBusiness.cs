using BookReading.Data;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
   public class EventBusiness
    {
        EventData eventData;
        public EventBusiness()
        {
            eventData = new EventData();
        }

        public Event AddEvents(Event readingEvent)
        {
            return eventData.AddEvents(readingEvent);
        }
        public List<Event> GetEvents()
        {
            return eventData.GetEvents();
        }
        public bool EditEvents(Event readingEvent, int userId)
        {
            return eventData.EditEvents(readingEvent, userId);
        }

        public Event GetEventDetails(int id)
        {
            return eventData.GetEventDetails(id);
        }
        public bool DeleteEvent(int id)
        {
            return eventData.DeleteEvent(id);
        }


        public IEnumerable<Event> GetCreatedEvent(int userId)
        {
            return eventData.GetCreatedEvent(userId);
        }


        public List<Event> GetInvitedEvent()
        {
            return eventData.GetInvitedEvent();
        }


        public IEnumerable<Event> GetPublicEvent()
        {
            return eventData.GetPublicEvent();
        }
    }
}
