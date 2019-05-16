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
        //Hämtar lista över alla bokningar som är gjorde och skickar det till vyn.
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

        //hämtar input från sökfältet och hämtar de bokningar som matchar sökordet.
        //Hittar den inget som matchar returneras ingenting.
        //Är input tomt så returneras hela listan med alla bokningar.
        public async Task<ActionResult> SearchBooking(string searchString)
        {
            try
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
                else
                {
                    return RedirectToAction("BookingList");
                }
            }
            catch
            {
                return RedirectToAction("BookingList");
            }
        }
        
        //Sorterar och hämtar alla bokningar i bokstavsordning efter namnet på systemet.
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

        //Sorterar och hämtar alla bokningar i bokstavsordning efter Namnet på användaren.
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

        //Returnerar vyn för att skapa en bokning samt har med ID på bokningssystemet i en viewBag.
        public ActionResult CreateBooking(int id)
        {
            ViewBag.id = id;
            return View();
        }

        //Hämtar den bokningen som man vill ändra och returnerar den till vyn.
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

        //Skickar tillbaka den bokningen som vi hämtade i metoden ovanför med de eventuellt ändrade fälten. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBooking(Bookings booking)
        {
            {
                var url = "http://localhost:64034/api/editBooking";
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
        }
        //Hämtar den bokningen som man vill ta bort och returnerar den till vyn.
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

        ////Skickar tillbaka den bokningen som vi hämtade i metoden ovanför för att ta bort den. 
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
    }
}