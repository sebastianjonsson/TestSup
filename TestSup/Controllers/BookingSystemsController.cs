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
        public ActionResult Index()
        {
            var bookingSystems = db.Bus.ToList();
            return View(bookingSystems);
        }
        public ActionResult RecBookingSys (string Cat, int Id, string Lat, string Long)
        {
            try
            {
                var booksys = db.Bus.Where(i => i.Category == Cat && i.Id != Id).ToList();
                return View(new RecBookingSys { BookSys = booksys });
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            try
            {
                var bookingSystems = from m in db.Bus
                            select m;

                if (!String.IsNullOrEmpty(searchString))
                {
                    bookingSystems = bookingSystems.Where(s => s.SystemName.Contains(searchString));
                }

                return View("Index", bookingSystems);
            }
            catch
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult SortByName()
        {
            var sortSystem = db.Bus.OrderBy(x => x.SystemName).ToList();
            return View("Index", sortSystem);
        }
        public ActionResult SortByCity()
        {
            var sortSystem = db.Bus.OrderBy(x => x.City).ToList();
            return View("Index", sortSystem);
        }
        public ActionResult SortByCategory()
        {
            var sortSystem = db.Bus.OrderBy(x => x.Category).ToList();
            return View("Index", sortSystem);
        }

        // GET: BookingSystems/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            var url = "http://localhost:64034/api/getBookingSystem/" + id;
            using (var client = new HttpClient())
            {
                var task = await client.GetAsync(url);
                var jsonString = await task.Content.ReadAsStringAsync();
                var bookingSystem = JsonConvert.DeserializeObject<BookingSystem>(jsonString);

                return View(bookingSystem);
            }

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //BookingSystem bookingSystem = db.Bus.Find(id);
            //if (bookingSystem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(bookingSystem);
        }
        public ActionResult Image(int id)
        {
            try
            {
                var image = db.Bus.Single(x => x.Id == id);
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
                var sys = db.Bus.Single(x => x.Id == Id);

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
                return RedirectToAction("Index");
            }
            catch
            {
                RedirectToAction("Index");
            }
            return View();
        }

        // GET: BookingSystems/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SystemName,SystemDescription,Email,PhoneNumber,Website,Address,City,Category,Longitude,Latitude")] BookingSystem bookingSystem, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                db.Bus.Add(bookingSystem);
                db.SaveChanges();

                var sys = db.Bus.Single(x => x.Id == bookingSystem.Id);
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

                return RedirectToAction("Index");
            }

            return View(bookingSystem);
        }

        public async Task<ActionResult> Edit(int? id)
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

        // POST: BookingSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingSystem bookingSystem)
        {
            if (ModelState.IsValid)
            {
                
                var sys = db.Bus.Single(x => x.Id == bookingSystem.Id);

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
                return RedirectToAction("Index");
            }
            return View(bookingSystem);
        }

        public async Task<ActionResult> Delete(int? id)
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

        // POST: BookingSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSystem bookingSystem = db.Bus.Find(id);
            db.Bus.Remove(bookingSystem);
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
    public class RecBookingSys
    {
        public string Cat { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public ICollection<BookingSystem> BookSys { get; set; }
        public RecBookingSys()
        {

        }
        public RecBookingSys(string Cat, int Id, string Lat, string Long)
        {
            using (var db = new DatabaseContext())
                {
                    this.BookSys = db.Bus.Where(i => i.Category == Cat && i.Id != Id).ToList();
                    this.Cat = Cat;
                    this.Lat = Lat;
                    this.Long = Long;
                
                }
            
         }
    }
}
