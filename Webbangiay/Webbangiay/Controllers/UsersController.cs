using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webbangiay.Models;

namespace Webbangiay.Controllers
{
    public class UsersController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(String id)
        {
            return View(db.Users.Where(s => s.Matk.Replace(" ", "") == id).FirstOrDefault());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            Users us = new Users();
            return View(us);
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users us)
        {
            try
            {
                // TODO: Add insert logic here
                if (us.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(us.ImageUpload.FileName);
                    string extension = Path.GetExtension(us.ImageUpload.FileName);
                    fileName = fileName + extension;
                    us.Avt = "~/Content/images/User/" + fileName;
                    us.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/User/"), fileName));
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

        // GET: Users/Edit/5
        public ActionResult Edit(String id)
        {
            return View(db.Users.Where(s => s.Matk.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(String  id, Users us)
        {
            try
            {
                // TODO: Add update logic here
                if (us.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(us.ImageUpload.FileName);
                    string extension = Path.GetExtension(us.ImageUpload.FileName);
                    fileName = fileName + extension;
                    us.Avt = "~/Content/images/User/" + fileName;
                    us.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/User/"), fileName));
                }
                db.Entry(us).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(String id)
        {
            return View(db.Users.Where(s => s.Matk.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, Users us)
        {
            try
            {
                // TODO: Add delete logic here
                us = db.Users.Where(s => s.Matk.Replace(" ", "") == id).FirstOrDefault();
                db.Users.Remove(us);
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
