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
    public class DonhangController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Donhang
        public ActionResult Index()
        {
            return View(db.Dathang.ToList());
        }

        // GET: Donhang/Details/5
       
        
        public ActionResult Details(String id)
        {
            return View(db.Dathang.Where(s => s.Madonhang.Replace(" ", "") == id).FirstOrDefault());
        }

        // GET: Donhang/Create
       

        // GET: Donhang/Edit/5
        public ActionResult Edit(String id)
        {
            return View(db.Dathang.Where(s => s.Madonhang.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Donhang/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Dathang dh)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(dh).State = EntityState.Modified;
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
