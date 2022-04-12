using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Monthayhung.Models;
using System.Data.SqlClient;

namespace Monthayhung.Controllers
{
    public class AccoutController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Accout
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source = ADMIN ; database=webbangiay; integrated security=SSPI;";
        }
      
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Users where Tentk='"+acc.Tentk+"'and Mk='"+acc.Mk+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                
                con.Close();
                ViewBag.Message = "Tai khoan khong dung";
                return View("Error");
            }    

       
        }
    }
}