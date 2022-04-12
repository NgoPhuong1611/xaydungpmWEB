using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monthayhung.Models;

namespace Monthayhung.Controllers
{
    public class RegisterController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Register
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        // GET: Users/Create
        public ActionResult Create()
        {
            User us = new User();
            return View(us);
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(User us)
        {
            try
            {
                // TODO: Add insert logic here
                if (us.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(us.ImageUpload.FileName);
                    string extension = Path.GetExtension(us.ImageUpload.FileName);
                    fileName = fileName + extension;
                    us.Avt = "~/Content/images/" + fileName;
                    us.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}