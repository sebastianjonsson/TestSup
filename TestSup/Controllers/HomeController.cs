using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic;

namespace TestSup.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string category)
        {
            try
            {
                if (category == null || category == "" || category == "Alla")
                {
                    var bookingSystems = db.DbBookingSystem.ToList();
                    Random random = new Random();
                    bookingSystems = bookingSystems.OrderBy(emp => random.Next()).ToList();
                    return View(bookingSystems);
                }
                else
                {
                    var bookingSystems = db.DbBookingSystem.Where(x => x.CreateBookingSystemCategory == category).ToList();
                    Random random = new Random();
                    bookingSystems = bookingSystems.OrderBy(emp => random.Next()).ToList();
                    return View(bookingSystems);
                }
                
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
        
}