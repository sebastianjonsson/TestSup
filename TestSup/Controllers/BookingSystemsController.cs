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
        // GET: BookingSystems
        public ActionResult BookingSystemList()
        {
            var bookingSystems = db.DbBookingSystem.ToList();
            return View(bookingSystems);
        }
        public ActionResult RecommendedBookingSystem(string Cat, int Id, string Lat, string Long)
        {
            try
            {
                var bookSystem = db.DbBookingSystem.Where(i => i.Category == Cat && i.Id != Id).ToList();
                return View(new RecommendedBookingSystem { BookSystem = bookSystem });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        public ActionResult SearchBookingSystem(string searchString)
        {
            try
            {
                var bookingSystems = from m in db.DbBookingSystem
                            select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    bookingSystems = bookingSystems.Where(s => s.SystemName.Contains(searchString));
                }

                return View("BookingSystemList", bookingSystems);
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult SortByName()
        {
            var sortSystem = db.DbBookingSystem.OrderBy(x => x.SystemName).ToList();
            return View("BookingSystemList", sortSystem);
        }
        public ActionResult SortByCity()
        {
            var sortSystem = db.DbBookingSystem.OrderBy(x => x.City).ToList();
            return View("BookingSystemList", sortSystem);
        }
        public ActionResult SortByCategory()
        {
            var sortSystem = db.DbBookingSystem.OrderBy(x => x.Category).ToList();
            return View("BookingSystemList", sortSystem);
        }

        // GET: BookingSystems/Details/5
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
        public ActionResult Image(int id)
        {
            try
            {
                var image = db.DbBookingSystem.Single(x => x.Id == id);
                return File(image.Picture, image.Content);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Picture(int Id, HttpPostedFileBase upload)
        {
            try
            {
                var sys = db.DbBookingSystem.Single(x => x.Id == Id);

                if (upload != null && upload.ContentLength > 0)
                {
                    sys.File = upload.FileName;

                    sys.Content = upload.ContentType;

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        sys.Picture = reader.ReadBytes(upload.ContentLength);
                    }
                    db.Entry(sys).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("BookingSystemList");
            }
            catch
            {
                RedirectToAction("BookingSystemList");
            }
            return View();
        }

        // GET: BookingSystems/Create
        public ActionResult CreateBookingSystem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookingSystem([Bind(Include = "Id,SystemName,SystemDescription,Email,PhoneNumber,Website,Address,City,Category,Longitude,Latitude")] BookingSystem bookingSystem, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.DbBookingSystem.Add(bookingSystem);
                db.SaveChanges();

                var sys = db.DbBookingSystem.Single(x => x.Id == bookingSystem.Id);
                if (upload != null && upload.ContentLength > 0)
                {
                    sys.File = upload.FileName;

                    sys.Content = upload.ContentType;

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        sys.Picture = reader.ReadBytes(upload.ContentLength);
                    }
                    db.Entry(sys).State = EntityState.Modified;
                }
                    db.SaveChanges();

                return RedirectToAction("BookingSystemList");
            }

            return View(bookingSystem);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create(BookingSystem bookingSystem)
        //{
        //    var url = "http://localhost:64034/api/createBookingSystem";
        //    using (var client = new HttpClient())
        //    {
        //        var content = new StringContent(JsonConvert.SerializeObject(bookingSystem), Encoding.UTF8, "application/json");
        //        var result = await client.PostAsync(url, content);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View(bookingSystem);
        //    }
        //}

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookingSystem(BookingSystem bookingSystem)
        {
            if (ModelState.IsValid)
            {
                
                var sys = db.DbBookingSystem.Single(x => x.Id == bookingSystem.Id);

                sys.Address = bookingSystem.Address;
                sys.Category = bookingSystem.Category;
                sys.City = bookingSystem.City;
                sys.Email = bookingSystem.Email;
                sys.PhoneNumber = bookingSystem.PhoneNumber;
                sys.Latitude = bookingSystem.Latitude;
                sys.Longitude = bookingSystem.Longitude;
                sys.SystemName = bookingSystem.SystemName;
                sys.SystemDescription = bookingSystem.SystemDescription;
                sys.Website = bookingSystem.Website;

                db.Entry(sys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BookingSystemList");
            }
            return View(bookingSystem);
        }

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

        [HttpPost, ActionName("DeleteBookingSystem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSystem bookingSystem = db.DbBookingSystem.Find(id);
            db.DbBookingSystem.Remove(bookingSystem);
            db.SaveChanges();
            return RedirectToAction("BookingSystemList");
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
    public class RecommendedBookingSystem
    {
        public string Cat { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public ICollection<BookingSystem> BookSystem { get; set; }
        public RecommendedBookingSystem()
        {

        }
        public RecommendedBookingSystem(string Cat, int Id, string Lat, string Long)
        {
            using (var db = new DatabaseContext())
                {
                    this.BookSystem = db.DbBookingSystem.Where(i => i.Category == Cat && i.Id != Id).ToList();
                    this.Cat = Cat;
                    this.Lat = Lat;
                    this.Long = Long;
                
                }
            
         }
    }
}
