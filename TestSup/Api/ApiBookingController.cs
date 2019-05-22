using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Logic.Models;
using TestSup.Repository;

namespace TestSup.Api
{
    public class ApiBookingController : ApiController
    {
        //Skapar en instans av vårt bookingRepository.
        BookingRepository bookingRepository = new BookingRepository();
        
        //Hämtar alla bokningssystem.
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

        //Hämtar de bokningarna som har samma starttid, datum och bokningssystemsID som det man försöker boka.
        //Detta för att se om tiden är ledig eller inte. 
        [HttpGet]
        [Route("api/getAllCreateBookings")]
        public IHttpActionResult GetAllCreateBookings(string startTime, int id, DateTime date)
        {
            var system = bookingRepository.GetAllCreateBookings(startTime, id, date);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        //Hämtar de bokningar som har samma datum och bokningssystemsID som det man försöker boka.
        //Detta för att se vilka tider den dagen har lediga.
        [HttpGet]
        [Route("api/getAllTimesDate")]
        public IHttpActionResult GetAllTimesDate(DateTime date, int id)
        {
            var system = bookingRepository.GetAllTimesDate(date, id);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        //Hämtar från repository med id.
        //Skickar bokningen till EditBooking och DeleteBooking i controllern.
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

        //Hämtar från repository och skickar bokningarna till controllern.
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

        //Hämtar från repository och skickar bokningarna till controllern.
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

        //Hämtar från repository och skickar bokningarna till controllern.
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

        //Skickar bokningen man vill lägga till till repository.
        //Varför vi gjorde denna genom ajax från vyn och direkt till APIcontrollern är 
        //för att vi inte vill returnera ny vy direkt när man skapar en bokning.
        [HttpPost]
        [Route("api/addBooking/")]
        public IHttpActionResult AddBooking(BookingViewModel booking)
        {
            bookingRepository.AddBooking(booking);
            return Ok();
        }

        //Skickar bokningen man vill ändra till repository.
        [HttpPost]
        [Route("api/editBooking/")]
        public IHttpActionResult EditBooking(Bookings booking)
        {
            bookingRepository.EditBooking(booking);
            return Ok();
        }

        //Skickar bokningen man vill ta bort till repository.
        [HttpPost]
        [Route("api/deleteBooking/")]
        public IHttpActionResult DeleteBooking(Bookings booking)
        {
            bookingRepository.DeleteBooking(booking);
            return Ok();
        }
    }
}
