using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestSup.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                var bookingSystems = db.Bus.ToList();
                Random rnd = new Random();
                bookingSystems = bookingSystems.OrderBy(emp => rnd.Next()).ToList();
                return View(bookingSystems);
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
        
}