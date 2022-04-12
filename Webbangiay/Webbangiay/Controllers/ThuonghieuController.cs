using Webbangiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Data.Entity;

namespace Webbangiay.Controllers
{
    public class ThuonghieuController : Controller
    {
        // GET: Thuonghieu
        Models.Model1 db = new Models.Model1();
        public ActionResult Index()
        {
            return View(db.Thuonghieu.ToList());
        }

        // GET: Thuonghieu/Details/5
        public ActionResult Details(String id)
        {
            return View(db.Thuonghieu.Where(s => s.Mathuonghieu.Replace(" ", "") == id).FirstOrDefault());
        }

        // GET: Thuonghieu/Create
        public ActionResult Create()
        {
            Thuonghieu th = new Thuonghieu();
            return View(th);
        }

        // POST: Thuonghieu/Create
        [HttpPost]
        public ActionResult Create(Thuonghieu th)
        {
            try
            {
                // TODO: Add insert logic here
                if (th.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(th.ImageUpload.FileName);
                    string extension = Path.GetExtension(th.ImageUpload.FileName);
                    fileName = fileName + extension;
                    th.Logo = "~/Content/images/thuonghieu/" + fileName;
                    th.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/thuonghieu/"), fileName));
                }
                db.Thuonghieu.Add(th);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thuonghieu/Edit/5
        public ActionResult Edit(String id)
        {
            return View(db.Thuonghieu.Where(s => s.Mathuonghieu.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Thuonghieu/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Thuonghieu th)
        {
            try
            {
                // TODO: Add update logic here
                if (th.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(th.ImageUpload.FileName);
                    string extension = Path.GetExtension(th.ImageUpload.FileName);
                    fileName = fileName + extension;
                    th.Logo = "~/Content/images/thuonghieu/" + fileName;
                    th.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/thuonghieu/"), fileName));
                }
                db.Entry(th).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thuonghieu/Delete/5
        public ActionResult Delete(String id)
        {
            return View(db.Thuonghieu.Where(s => s.Mathuonghieu.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Thuonghieu/Delete/5
        [HttpPost]
        public ActionResult Delete(String id,Thuonghieu th)
        {
            try
            {
                // TODO: Add delete logic here
                th = db.Thuonghieu.Where(s => s.Mathuonghieu.Replace(" ", "") == id).FirstOrDefault();
                db.Thuonghieu.Remove(th);
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
