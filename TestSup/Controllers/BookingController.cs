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
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestSup.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Posts
        public async Task<ActionResult> BookingList()
        {
            //var bookings = db.Book.ToList();
            //return View(bookings);

            var url = "http://localhost:64034/api/getAllBookings";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
                return View(booking);
            }
        }
        [HttpPost]
        public ActionResult SearchBooking(string searchString)
        {
            try
            {
                var bookings = from m in db.DbBookings
                                     select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    bookings = bookings.Where(s => s.BookingSystem.SystemName.Contains(searchString) || s.UserName.Contains(searchString));
                    //HEJSAN
                }
                return View("BookingList", bookings.ToList());
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<ActionResult> SortBySystemName()
        {
            var url = "http://localhost:64034/api/sortBookingBySystemName";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
                return View("BookingList", booking);
            }
        }
        public async Task<ActionResult> SortByName()
        {
            var url = "http://localhost:64034/api/sortBookingByName";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
                return View("BookingList", booking);
            }
        }


        public ActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking([Bind(Include = "Id,UserName,Email,UserMobile,Subject,StartTime,EndTime,BookingSys")] Bookings booking, int id)
        {
            if (ModelState.IsValid)
            {
                var sys = db.DbBookingSystem.Single(x => x.Id == id);
                booking.BookingSystem = sys;
                db.DbBookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("BookingList");
            }

            return View(booking);
        }
        
        // GET: BookingSystems/Edit/5
        public async Task<ActionResult> EditBooking(int? id)
        {
            var url = "http://localhost:64034/api/getBooking/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<Bookings>(jsonString);
                return View(booking);
            }
        }

        // POST: BookingSystems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBooking([Bind(Include = "Id, UserName, Email, UserMobile, Subject, StartTime, Endtime")] Bookings booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BookingList");
            }
            return View(booking);
        }

        // GET: BookingSystems/Delete/5
        public async Task<ActionResult> DeleteBooking(int? id)
        {
            var url = "http://localhost:64034/api/getBooking/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<Bookings>(jsonString);
                return View(booking);
            }
        }

        // POST: BookingSystems/Delete/5
        [HttpPost, ActionName("DeleteBooking")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings booking = db.DbBookings.Find(id);
            db.DbBookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("BookingList");
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