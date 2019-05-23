using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Logic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestSup.Controllers
{
    public class BookingSystemsController : BaseController
    {
        //Hämtar en lista över alla bokningssytem och skickar de till vyn.
        public async Task<ActionResult> BookingSystemList()
        {
            var url = "http://localhost:64034/api/getAllBookingSystem";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var bookingSystem = JsonConvert.DeserializeObject<List<BookingSystem>>(jsonString);
                return View(bookingSystem);
            }
        }
        
        //Action för att söka efter bokningssystem.
        public async Task<ActionResult> SearchBookingSystem(string searchString)
        {
            try
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    var url = "http://localhost:64034/api/searchBookingSystem/" + searchString;
                    using (var client = new HttpClient())
                    {
                        var task = await client.GetAsync(url);
                        var jsonString = await task.Content.ReadAsStringAsync();
                        var bookingSystem = JsonConvert.DeserializeObject<List<BookingSystem>>(jsonString);
                        return View("BookingSystemList", bookingSystem);
                    }
                }
                else
                {
                    return RedirectToAction("BookingSystemList");
                }
            }
            catch
            {
                return RedirectToAction("BookingSystemList");
            }
        }

        //Action för att sortera bokningssystem efter namn.
        public async Task<ActionResult> SortByName()
        {
            var url = "http://localhost:64034/api/sortBookingSystemByName";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var sortBookingSystem = JsonConvert.DeserializeObject<List<BookingSystem>>(jsonString);
                return View("BookingSystemList", sortBookingSystem);
            }
        }

        //Action för att sortera bokningssystem efter stad.
        public async Task<ActionResult> SortByCity()
        {
            var url = "http://localhost:64034/api/sortBookingSystemByCity";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var sortBookingSystem = JsonConvert.DeserializeObject<List<BookingSystem>>(jsonString);
                return View("BookingSystemList", sortBookingSystem);
            }
        }

        //Action för att sortera bokningssystem efter kategori.
        public async Task<ActionResult> SortByCategory()
        {
            var url = "http://localhost:64034/api/sortBookingSystemByCategory";
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var sortBookingSystem = JsonConvert.DeserializeObject<List<BookingSystem>>(jsonString);
                return View("BookingSystemList", sortBookingSystem);
            }
        }

        //Hämtar ett bokningssystem och visar bokningssystemet i vyn.
        public async Task<ActionResult> DetailsBookingSystem(int? id)
        {

            var url = "http://localhost:64034/api/getBookingSystem/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var bookingSystem = JsonConvert.DeserializeObject<BookingSystem>(jsonString);

                return View(bookingSystem);
            }
        }

        //Action för att visa bokningsystemets bild.
        public ActionResult Image(int id)
        {
            try
            {
                var image = db.DbBookingSystem.Single(x => x.Id == id);
                return File(image.Picture, image.PictureContent);
            }
            catch
            {
                return View();
            }
        }
        
        //Returnerar vyn för att skapa ett bokningssystem.
        public ActionResult CreateBookingSystem()
        {
            return View();
        }

        //Action för att skapa bokningssystem.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateBookingSystem(BookingSystem bookingSystem, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                bookingSystem.PictureFile = upload.FileName;

                bookingSystem.PictureContent = upload.ContentType;

                using (var reader = new BinaryReader(upload.InputStream))
                {
                    bookingSystem.Picture = reader.ReadBytes(upload.ContentLength);
                }
             }
            var url = "http://localhost:64034/api/addBookingSystem";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(bookingSystem), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookingSystemList");
                }
                return View(bookingSystem);
            }
        }

        //Hämtar ett bokningssystem som ska ändras och tar med bokningssystemets attribut till vyn.
        public async Task<ActionResult> EditBookingSystem(int? id)
        {
            var url = "http://localhost:64034/api/getBookingSystem/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var bookingSystem = JsonConvert.DeserializeObject<BookingSystem>(jsonString);
                return View(bookingSystem);
            }
        }

        //Action för att ändra ett bokningssystem.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBookingSystem(BookingSystem bookingSystem)
        {
            {
                var url = "http://localhost:64034/api/editBookingSystem";
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(bookingSystem), Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(url, content);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("BookingSystemList");
                    }
                    return View(bookingSystem);
                }
            }
        }

        //Hämtar bokningssystemet som ska tas bort.
        public async Task<ActionResult> DeleteBookingSystem(int? id)
        {
            var url = "http://localhost:64034/api/getBookingSystem/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var bookingSystem = JsonConvert.DeserializeObject<BookingSystem>(jsonString);
                return View(bookingSystem);
            }
        }

        //Action för att ta bort bokningssystem.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBookingSystem (BookingSystem bookingSystem)
        {
            var url = "http://localhost:64034/api/deleteBookingSystem";
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(bookingSystem), Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("BookingSystemList");
                }
                return View();
            }
        }
        
    }
}
