using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using GioHang2.Models;


namespace GioHang2.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        webbangiayEntities1 _database = new webbangiayEntities1();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        [HttpGet]
        public ActionResult AddtoCart(string id)
        {

            var l = _database.Sanphams.SingleOrDefault(s => s.Masp == id);
            if (l != null)
            {
                GetCart().Add(l);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);

        }
        public ActionResult UpdateToCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            string id = form["id_product"];
            int quantity = int.Parse(form["quantity_product"]);
            cart.Update(id, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart c = Session["Cart"] as Cart;
            if (c != null)
                total_item = c.Total_Quantity_InCart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");

        }
        public ActionResult SSShopping()
        {
            return View();
        }
        public ActionResult Payment(FormCollection form)
        {
            try
            {
                String ma;
                Cart cart = Session["Cart"] as Cart;
                Random A = new Random();
                ma = A.Next(1, 10000).ToString();
                foreach (var item in cart.Items)
                {
                    
                    Dathang dathang = new Dathang();
                    dathang.Madonhang = ma;
                    dathang.Ngaytao = DateTime.Now;
                    dathang.Tinhtrang = "có hàng";
                    dathang.Ghichu = form["note"];
                    dathang.Soluong = item._shoppingQuantity;
                    dathang.Matk = form["codeuser"];
                    dathang.Masp = item._shoppingSP.Masp;
                    dathang.Ngaygiaodukien = DateTime.Parse(form["ddate"]);
                    _database.Dathangs.Add(dathang);
                }
                _database.SaveChanges();
                cart.ClearCart();

                return RedirectToAction("SSShopping", "ShoppingCart");
            }
            catch
            {
                return Content("Error Payment");
            }
        }
    }
}