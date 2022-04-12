using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webbangiay.Controllers
{
    public class HomeController : Controller
    {
        Models.Model1 db = new Models.Model1();
       
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username.Equals("Admin") && password.Equals("Pass1234"))
            {
                Session["username"] = "username";
                return View("Index");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Login");
            }
        }

    }
}