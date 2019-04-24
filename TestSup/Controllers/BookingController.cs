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
using System.Text;

namespace TestSup.Controllers
{
    public class BookingController : BaseController
    {
        // GET: Posts
        public async Task<ActionResult> BookingList()
        {
            var url = "http://localhost:64034/api/getAllBookings";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
                return View(booking);
            }
        }
 
        public async Task<ActionResult> SearchBooking(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var url = "http://localhost:64034/api/searchBooking/" + searchString;
                using (var client = new HttpClient())
                {
                    var task = await client.GetAsync(url);
                    var jsonString = await task.Content.ReadAsStringAsync();
                    var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
                    return View("BookingList", booking);
                }
            }
            return View("BookingList");
            //Detta är nog fel.
            //else
            //{
            //    var url = "http://localhost:64034/api/getAllBookings";
            //    using (var client = new HttpClient())
            //    {
            //        var task = await client.GetAsync(url);
            //        var jsonString = await task.Content.ReadAsStringAsync();
            //        var booking = JsonConvert.DeserializeObject<List<Bookings>>(jsonString);
            //        return View("BookingList", booking);
            //    }
            //}
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
        public async Task<ActionResult> CreateBooking(Bookings booking, int id)
        {
            var system = db.DbBookingSystem.Single(x => x.Id == id);
            booking.BookingSystem = system;
            var url = "http://localhost:64034/api/addBooking";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookingList");
                }
                return View(booking);
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBooking(Bookings booking)
        {
            var url = "http://localhost:64034/api/deleteBooking";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookingList");
                }
                return View();
            }
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