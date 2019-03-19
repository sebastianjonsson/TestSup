using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSup.Models;
using Logic;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

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
      
        public ActionResult Book(Bookings book, int id, string UserName, string email, int userMobile, string subject, DateTime startTime, DateTime endTime)
        {
            try
            {
                var sys = db.Bus.Single(x => x.Id == id);
                book.UserName = UserName;
                book.Email = email;
                book.Subject = subject;
                book.UserMobile = userMobile;
                book.StartTime = startTime;
                book.Endtime = endTime;
                book.BookingSys = sys;
                db.Book.Add(book);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Details", "BookingSystems", new { Id = id });
            }
            return RedirectToAction("Index", "Booking", new { Id = id });
        }

        // GET: BookingSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings booking = db.Book.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: BookingSystems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, UserName, Email, UserMobile, Subject, StartTime, Endtime")] Bookings booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: BookingSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings booking = db.Book.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: BookingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings booking = db.Book.Find(id);
            db.Book.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
    public class BookingIndexViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Namn")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Telefonnummer")]
        public int UserMobile { get; set; }
        [Display(Name = "Detaljer")]
        public string Subject { get; set; }
        [Display(Name = "Starttid")]
        public DateTime StartTime { get; set; }
        [Display(Name = "Sluttid")]
        public DateTime Endtime { get; set; }
        [Display(Name = "Verksamhet")]
        public int BookingSystemID { get; set; }
        public ICollection<Bookings> Bookings { get; set; }
        public BookingIndexViewModel()
        {

        }
    }
}