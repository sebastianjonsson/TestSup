using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSup.Models;
using Logic;

namespace TestSup.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Posts
        public ActionResult Index()
        {
            try
            {
                var booking = db.Book.ToList();
                return View(new BookingIndexViewModel { Bookings = booking });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();

        }
        public ActionResult Book(Bookings book, int id, string userName, string email)
        {
            try
            {
                var sys = db.Bus.Single(x => x.Id == id);
                book.UserName = userName;
                book.Email = email;
                book.BookingSys = sys;
                db.Book.Add(book);
                db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToAction("Index", "Booking", new { Id = id });
        }

    }
    public class BookingIndexViewModel
    {
        public string Id { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public BookingIndexViewModel()
        {

        }
    }
}