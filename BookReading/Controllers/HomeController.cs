﻿using BookReading.BusinessFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReading.Controllers
{
    public class HomeController : Controller
    {
        EventFacade eventFacade;
        UserController userController;
        public HomeController()
        {
            eventFacade = new EventFacade();
            userController = new UserController();
        }
        public ActionResult Index()
        {
            Session["userId"] = 0;
            var output = eventFacade.GetPublicEvents();

            return View(output);
        }

        public ActionResult Index_Authenticated()
        {
            var test = userController.CheckLoginUser();
            if (!test)
            {
                return Redirect("/User/Login");
            }
            var output = eventFacade.GetPublicEvents();

            return View("Index", output);
            
             
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}