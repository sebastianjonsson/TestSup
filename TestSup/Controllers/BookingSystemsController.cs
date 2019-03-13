using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logic;

namespace TestSup.Controllers
{
    public class BookingSystemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: BookingSystems
        public ActionResult Index()
        {
            return View(db.Bus.ToList());
        }

        // GET: BookingSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSystem bookingSystem = db.Bus.Find(id);
            if (bookingSystem == null)
            {
                return HttpNotFound();
            }
            return View(bookingSystem);
        }

        // GET: BookingSystems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SystemName,SystemDescription,Email,PhoneNumber,Website,Address,LatitudeLongitude,City,Category")] BookingSystem bookingSystem)
        {
            if (ModelState.IsValid)
            {
                db.Bus.Add(bookingSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingSystem);
        }

        // GET: BookingSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSystem bookingSystem = db.Bus.Find(id);
            if (bookingSystem == null)
            {
                return HttpNotFound();
            }
            return View(bookingSystem);
        }

        // POST: BookingSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SystemName,SystemDescription,Email,PhoneNumber,Website,Address,LatitudeLongitude,City,Category")] BookingSystem bookingSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingSystem);
        }

        // GET: BookingSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSystem bookingSystem = db.Bus.Find(id);
            if (bookingSystem == null)
            {
                return HttpNotFound();
            }
            return View(bookingSystem);
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
}
