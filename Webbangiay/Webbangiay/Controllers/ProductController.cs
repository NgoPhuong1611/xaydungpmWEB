using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using Webbangiay.Models;
using System.Data.Entity;

namespace Webbangiay.Controllers
{
    public class ProductController : Controller
    {
        Models.Model1 db = new Models.Model1();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Sanpham.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(String id)
        {
            
            return View(db.Sanpham.Where(s=>s.Masp.Replace(" ", "") == id).FirstOrDefault() );
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Sanpham sanpham = new Sanpham();
            return View(sanpham);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Sanpham sp)
        {
            try
            {
                // TODO: Add insert logic here
                if(sp.ImageUpload!=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                    string extension = Path.GetExtension(sp.ImageUpload.FileName);
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        Response.Write("<script>alert('Vui lòng chọn file ảnh có đuôi jpg,png hoặc jpeg!')</script>");
                    }
                    else
                    {
                        fileName = fileName + extension;
                        sp.Anhsp = "~/Content/images/anhsp/" + fileName;
                        sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/anhsp/"), fileName));
                    }
                }
                db.Sanpham.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            return View(db.Sanpham.Where(s => s.Masp.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Sanpham sp)
        {
            try
            {
                // TODO: Add update logic here
                if (sp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                    string extension = Path.GetExtension(sp.ImageUpload.FileName);
                    if (extension != ".jpg" && extension != ".png" && extension != ".jpeg")
                    {
                        Response.Write("<script>alert('Vui lòng chọn file ảnh có đuôi jpg,png hoặc jpeg!')</script>");
                    }
                    else
                    {
                        fileName = fileName + extension;
                        sp.Anhsp = "~/Content/images/anhsp/" + fileName;
                        sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/anhsp/"), fileName));
                    }
                }
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(String id)
        {
            return View(db.Sanpham.Where(s => s.Masp.Replace(" ", "") == id).FirstOrDefault());
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, Sanpham sp)
        {
            try
            {
                // TODO: Add delete logic here
                sp= db.Sanpham.Where(s => s.Masp.Replace(" ", "") == id).FirstOrDefault();
                db.Sanpham.Remove(sp);
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
