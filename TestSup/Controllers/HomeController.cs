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
        public ActionResult Index(string cat)
        {
            try
            {
                var bookingSystems = db.Bus.ToList();
                bookingSystems = bookingSystems.Where(x => x.Category == cat).ToList();
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