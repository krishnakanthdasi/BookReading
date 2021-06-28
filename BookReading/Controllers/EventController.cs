using BookReading.BusinessFacades;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReading.Controllers
{
    public class EventController : Controller
    {
        EventFacade eventFacade;
        UserController userController;
        UserFacade userFacade;
        public EventController()
        {
            eventFacade = new EventFacade();
            userController = new UserController();
            userFacade = new UserFacade();
        }
        // GET: Event
        public ActionResult Index()
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            return View();
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create

        [HttpPost]
        public ActionResult Create(EventModel events, FormCollection Fc)
        {

            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            events.UserId = userController.LoggedUserId();
            
            bool result = eventFacade.addEvents(events);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            if (id == 0)
            {
                return HttpNotFound();
            }
            var output = eventFacade.GetEventDetails(id);
            return View(output);
        }

        // Function To Edit the Event
        public ActionResult UpdateEvent(Event ev)
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            eventFacade.EditEvents(ev, userController.LoggedUserId());

            return Redirect("/User/Event/Index");
        }

        // Function TO View Invitation Form
        public ActionResult Invite(int id)
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }
            var output = eventFacade.GetEventDetails(id);
            ViewBag.eventId = id;
            ViewBag.userlist = userFacade.UserIds(userController.LoggedUserId());
            return View(output);
        }

        // Function To Invite Registered User
        public ActionResult InviteUser()
        {
            string userId = Request.Form["userId"];
            string eventId = Request.Form["eventId"];
            char[] spearator = { ',', ' ' };
            string[] userIds = userId.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

            eventFacade.inviteUser(Int32.Parse(eventId), Array.ConvertAll(userIds, int.Parse));
            return Redirect("/Event/ViewMyEvent");
        }

        // Function To Event Created By User
        public ActionResult ViewMyEvent()
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            var output = eventFacade.GetCreatedEvent(userController.LoggedUserId());

            return View(output);
        }

        // Function To View Public Event
        public ActionResult PublicEvents()
        {
            var output = eventFacade.GetPublicEvent();
            return View(output);
        }

        // Function To View Event Detail
        public ActionResult ViewPublicDetail(int id)
        {
            var output = eventFacade.GetEventDetails(id);
            return View(output);
        }

        // Function To View Upcoming Event
        public ActionResult UpcomingEvents()
        {
            var output = eventFacade.GetPublicEvent();
            return View(output);
        }

        // Function To View Past Event
        public ActionResult PastEvents()
        {
            var output = eventFacade.GetPublicEvent();
            return View(output);
        }

        // Function to Show Delete Form of an Event
        public ActionResult Delete(int id)
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }

            var output = eventFacade.GetEventDetails(id);
            ViewBag.eventid = id;
            return View();
        }

        // Function To Delete An Event
        public ActionResult DeleteEvent(int id)
        {
            bool result = eventFacade.DeleteEvent(id);
            return Redirect("/User/Event/ViewMyEvent");
        }

        public ActionResult Invitations()
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }
            // System.Diagnostics.Debug.WriteLine(userController.LoggedUserId());
            var userInvitations = eventFacade.getInvitation(userController.LoggedUserId());
            List<Event> getEvent = new List<Event>();
            foreach (var output in userInvitations)
            {
                // System.Diagnostics.Debug.WriteLine(output.EventId);
                getEvent.Add(eventFacade.GetEventDetails(output.EventId));
            }
            return View(getEvent);
        }
    }
}
