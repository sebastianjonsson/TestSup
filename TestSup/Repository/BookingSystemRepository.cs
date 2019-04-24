using Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestSup.Controllers;

namespace TestSup.Repository
{
    public class BookingSystemRepository : BaseController
    {
        public async Task<BookingSystem> GetBookingSystem(int id)
        {
            BookingSystem bookingSystem =  db.DbBookingSystem.Find(id);
            return (bookingSystem);
        }
        public void AddBookingSystem(BookingSystem bookingSystem/*, HttpPostedFileBase upload*/)
        {
            db.DbBookingSystem.Add(bookingSystem);
            db.SaveChanges();

            //var system = db.DbBookingSystem.Single(x => x.Id == bookingSystem.Id);
            //if (upload != null && upload.ContentLength > 0)
            //{
            //    system.File = upload.FileName;

            //    system.Content = upload.ContentType;

            //    using (var reader = new BinaryReader(upload.InputStream))
            //    {
            //        system.Picture = reader.ReadBytes(upload.ContentLength);
            //    }
            //}
            //db.SaveChanges();
        }

        public void EditBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystem.Address = bookingSystem.Address;
            bookingSystem.Category = bookingSystem.Category;
            bookingSystem.City = bookingSystem.City;
            bookingSystem.Email = bookingSystem.Email;
            bookingSystem.PhoneNumber = bookingSystem.PhoneNumber;
            bookingSystem.Latitude = bookingSystem.Latitude;
            bookingSystem.Longitude = bookingSystem.Longitude;
            bookingSystem.SystemName = bookingSystem.SystemName;
            bookingSystem.SystemDescription = bookingSystem.SystemDescription;
            bookingSystem.Website = bookingSystem.Website;

            db.Entry(bookingSystem).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}