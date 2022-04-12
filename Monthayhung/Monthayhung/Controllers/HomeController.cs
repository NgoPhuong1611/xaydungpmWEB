using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace chude2.Controllers
{
    public class HomeController : Controller
    {
        webbangiayEntities1 _database = new webbangiayEntities1();
        public ActionResult Index()
        {
            return View(_database.Sanphams.ToList());
        }

        public ActionResult Indexx()
        {

            return View(_database.Sanphams.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}