using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestSup.Models;
using TestSup.Repository;

namespace TestSup.Api
{
    public class ApiBookingController : ApiController
    {
        BookingRepository bookingRepository = new BookingRepository();
        // GET: api/ApiBooking
        [HttpGet]
        [Route("api/getAllBookings")]
        public IHttpActionResult GetAllBookings()
        {
            var system = bookingRepository.GetAllBookings();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        // GET: api/ApiBooking/5
        [HttpGet]
        [Route("api/getBooking/{id}")]
        public IHttpActionResult GetBooking(int id)
        {
            var system = bookingRepository.GetBooking(id);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        [HttpGet]
        [Route("api/sortBookingBySystemName")]
        public IHttpActionResult SortBookingBySystemName()
        {
            var system = bookingRepository.SortBookingsBySystemName();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        [HttpGet]
        [Route("api/sortBookingByName")]
        public IHttpActionResult SortBookingByName()
        {
            var system = bookingRepository.SortBookingsByName();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        [HttpGet]
        [Route("api/searchBooking/{searchString}")]
        public IHttpActionResult SearchBooking(string searchString)
        {
            var system = bookingRepository.SearchBooking(searchString);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        //[HttpPost]
        //[Route("api/addBooking/")]
        //public IHttpActionResult AddBooking(Bookings booking)
        //{
        //    bookingRepository.AddBooking(booking);
        //    return Ok();
        //}

        [HttpPost]
        [Route("api/newBooking/{id}")]
        public void NewBooking([FromBody] Bookings booking, int id)
        {
            //try
            //{
            //    using (var db = new DatabaseContext())
            //    {
            //var system = db.DbBookingSystem.Single(x => x.Id == url);
            //booking.BookingSystem = system;

            //        //db.DbBookings.Add(new Bookings()
            //        //{
            //        //    UserName = booking.UserName,
            //        //    Email = booking.Email,
            //        //    UserMobile = booking.UserMobile.ToString(),
            //        //    Subject = booking.Subject,
            //        //    StartTime = booking.StartTime,
            //        //    Endtime = booking.Endtime,
            //        //});
            //        db.DbBookings.Add(booking);
            //        db.SaveChanges();
            //    }
            //}
            //catch (Exception e)
            //{
            //    System.Diagnostics.Debug.WriteLine(e.Message);
            //}
            bookingRepository.AddBooking(booking);

        }

        [HttpPost]
        [Route("api/editBooking/")]
        public IHttpActionResult EditBooking(Bookings booking)
        {
            bookingRepository.EditBooking(booking);
            return Ok();
        }

        [HttpPost]
        [Route("api/deleteBooking/")]
        public IHttpActionResult DeleteBooking(Bookings booking)
        {
            bookingRepository.DeleteBooking(booking);
            return Ok();
        }

        // POST: api/ApiBooking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApiBooking/5
        public void Put(int id, [FromBody]string value)
        {
        }
        
    }
}
