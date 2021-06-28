using BookReading.BusinessFacades;
using BookReading.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReading.Controllers
{
    public class UserController : Controller
    {
        private UserFacade userFacade;

        public UserController()
        {
            userFacade = new UserFacade();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public string GetUserRole(int userId)
        {
            
            var role = userFacade.getRole(userId);
            return role;
        }
        public ActionResult Registeration()
        {
            string username = Request.Form["UserName"];
            string useremail = Request.Form["UserEmail"];
            string password = Request.Form["UserPassword"];

            System.Diagnostics.Debug.WriteLine(username);
            System.Diagnostics.Debug.WriteLine(useremail);
            System.Diagnostics.Debug.WriteLine(password);

            if (username == null || username == "" || useremail == null || useremail == "" || password == null || password == "")
            {
                return RedirectToAction("Register");
            }
            User usr = new User();
            usr.UserName = username;
            usr.UserEmail = useremail;
            usr.UserPassword = password;
            usr.UserRole = "U";

            bool result =  userFacade.addUser(usr);
            if (result)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }
        public ActionResult Register()
        {
            Session["userId"] = 0;
            return View();
        }
        public ActionResult Validate()
        {

            string useremail = Request.Form["UserEmail"];
            string password = Request.Form["UserPassword"];

            System.Diagnostics.Debug.WriteLine(useremail);
            System.Diagnostics.Debug.WriteLine(password);

            if (useremail != null && useremail != "" && password != null && password != "")
            {

                int userId = userFacade.checkUser(useremail, password);
                if (userId != 0)
                {
                    Session["userId"] = userId;
                    System.Diagnostics.Debug.WriteLine((int)Session["userId"]);
                    return RedirectToAction("Index_Authenticated", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public bool CheckLoginUser()
        {
            int userId = (int)System.Web.HttpContext.Current.Session["userId"];

            if (userId > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckLogged()
        {
            bool loggedUserId = CheckLoginUser();
            
            if (!loggedUserId)
            {
                redirectLogin();
            }
             
        }

        public ActionResult redirectLogin()
        {
            
            return RedirectToAction("Login", "User");
            
        }

        public int LoggedUserId()
        {

            var log = CheckLoginUser();
            int userId = 0;
            if (log)
            {
                userId = (int)System.Web.HttpContext.Current.Session["userId"];
            }

            return userId;
        }

    }
}