using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestSup.Controllers
{
    public class RecommendedBookingSystemController : BaseController
    {
        //Hämtar en lista över rekommenderade bokningssytem som är inom specifika kategorier som skickas vidare till vyn.
        public ActionResult RecommendedBookingSystem(int id)
        {
            try
            {
                var yourBookingSystem = db.DbBookingSystem.Single(x => x.Id == id);
                var bookingSystem = db.DbBookingSystem.Where(i => i.CreateBookingSystemCategory != yourBookingSystem.CreateBookingSystemCategory && i.Id != id).ToList();
                return View(new RecommendedBookingSystem { BookingSystem = bookingSystem });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
    //Class för rekommenderade bokningssystem.
    public class RecommendedBookingSystem
    {
        public string Category { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public ICollection<BookingSystem> BookingSystem { get; set; }
        public RecommendedBookingSystem()
        {

        }
        public RecommendedBookingSystem(int id)
        {
            using (var db = new DatabaseContext())
            {
                var yourBookingSystem = db.DbBookingSystem.Single(x => x.Id == id);
                this.BookingSystem = db.DbBookingSystem.Where(i => i.CreateBookingSystemCategory != yourBookingSystem.CreateBookingSystemCategory && i.Id != id).ToList();
                this.Category = yourBookingSystem.CreateBookingSystemCategory;
                this.Lat = yourBookingSystem.Latitude;
                this.Long = yourBookingSystem.Longitude;
            }
        }
    }
}