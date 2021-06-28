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
        UserBusiness userBusiness;
        InvitationBusiness invitationBusiness;
        public EventFacade()
        {
            eventBusiness = new EventBusiness();
            userBusiness = new UserBusiness();
            invitationBusiness = new InvitationBusiness();
        }

        public IEnumerable<Event> GetPublicEvents()
        {
            return eventBusiness.GetPublicEvent();
        }

        public Boolean addEvents(EventModel eventModel)
        {
            Event evnt = new Event
            {

                EventName = eventModel.EventName,


                EventDescription = eventModel.EventDescription,

                EventOtherDetails = eventModel.EventOtherDetails,
                EventLocation = eventModel.EventLocation,

                EventDuration = eventModel.EventDuration,

                EventType = eventModel.EventType,



                EventDate = eventModel.EventDate,

                EventStartTime = eventModel.EventStartTime,

                EventActive = eventModel.EventActive,

                UserId = eventModel.UserId
            };
             evnt = eventBusiness.AddEvents(evnt);
            if (eventModel.userInvitation != null)
            {
                string[] userEmails = eventModel.userInvitation.Split(';');
                int[] userids = new int[userEmails.Length];
                for (int i = 0; i < userEmails.Length; i++)
                {
                    int userid = userBusiness.getUserId(userEmails[i]);
                    userids[i] = userid;
                }

                return invitationBusiness.inviteUser(evnt.EventId, userids);
            }
            return true;

        }

        public List<Event> GetEvents()
        {
            return eventBusiness.GetEvents();
        }
        public bool EditEvents(Event readingEvent, int userId)
        {
            return eventBusiness.EditEvents(readingEvent, userId);
        }

        public Event GetEventDetails(int id)
        {
            return eventBusiness.GetEventDetails(id);
        }
        public bool DeleteEvent(int id)
        {
            return eventBusiness.DeleteEvent(id);
        }


        public IEnumerable<Event> GetCreatedEvent(int userId)
        {
            return eventBusiness.GetCreatedEvent(userId);
        }


        public List<Event> GetInvitedEvent()
        {
            return eventBusiness.GetInvitedEvent();
        }


        public IEnumerable<Event> GetPublicEvent()
        {
            return eventBusiness.GetPublicEvent();
        }

        public bool addInvitation(Invitation invitation)
        {
            return invitationBusiness.addInvitation(invitation);
        }

        public IEnumerable<Invitation> getInvitation(int userId)
        {
            return invitationBusiness.getInvitation(userId);
        }


        public bool inviteUser(int eventId, int[] userId)
        {

            return invitationBusiness.inviteUser(eventId, userId);
        }
    }
}
