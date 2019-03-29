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
            var bookings = db.Book.ToList();
            return View(bookings);
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            try
            {
                var bookings = from m in db.Book
                                     select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    bookings = bookings.Where(s => s.BookingSys.SystemName.Contains(searchString) || s.UserName.Contains(searchString));
                    //HEJSAN
                }
                return View("Index", bookings.ToList());
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult SortBySystemName()
        {
            var sort = db.Book.OrderBy(x => x.BookingSys.SystemName).ToList();
            return View("Index", sort);
        }
        public ActionResult SortByName()
        {
            var sort = db.Book.OrderBy(x => x.UserName).ToList();
            return View("Index", sort);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Email,UserMobile,Subject,StartTime,EndTime,BookingSys")] Bookings book, int id)
        {
            if (ModelState.IsValid)
            {
                var sys = db.Bus.Single(x => x.Id == id);
                book.BookingSys = sys;
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
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
}