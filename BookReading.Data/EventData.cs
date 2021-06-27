using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Data
{
    public class EventData
    {
        private BookReadingDBContext db;
        public EventData()
        {
            db = new BookReadingDBContext();
        }
        public Boolean AddEvents(Event readingEvent)
        {
            if (readingEvent == null)
            {
                return false;
            }

            if (readingEvent.EventDate == null || readingEvent.EventDescription == null || readingEvent.EventLocation == null ||
                readingEvent.EventName == null || readingEvent.EventOtherDetails == null || readingEvent.EventStartTime == null)
            {
                return false;
            }

            db.Events.Add(readingEvent);
            db.SaveChanges();
            return true;

        }
        public List<Event> GetEvents()
        {
            var events = db.Events.ToList();
            return events;
        }
        public bool EditEvents(Event readingEvent, int userId)
        {
            readingEvent.UserId = userId;
            db.Entry(readingEvent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Event GetEventDetails(int id)
        {
            var readingEvent = db.Events.Single(x => x.EventId == id);
            return readingEvent;
        }
        public bool DeleteEvent(int id)
        {
            var output = db.Events.Single(x => x.EventId == id);
            if (output == null)
            {
                return false;
            }

            db.Events.Remove(output);
            db.SaveChanges();

            
            var outputs = db.Invitations.Where(d => d.EventId == id);
            foreach (var x in outputs)
            {
                db.Invitations.Remove(x);
            }

            return true;
        }

        
        public IEnumerable<Event> GetCreatedEvent(int userId)
        {

            var output = GetEvents().Where(d => d.UserId == userId);

            return output;
        }

        
        public List<Event> GetInvitedEvent()
        {
            var output = db.Events.ToList();
            return output;
        }

        
        public IEnumerable<Event> GetPublicEvent()
        {
            var output = GetEvents().Where(d => d.EventType == 2);
            return output;
        }
    }
}
