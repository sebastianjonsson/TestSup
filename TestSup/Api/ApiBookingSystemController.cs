using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TestSup.Repository;

namespace TestSup.Api
{

    public class ApiBookingSystemController : ApiController
    {
        BookingSystemRepository bookingSystemRepository = new BookingSystemRepository();

        [HttpGet]
        [Route("api/getAllBookingSystem")]
        public IHttpActionResult GetAllBookingSystem()
        {
            var system = bookingSystemRepository.GetAllBookingSystem();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/searchBookingSystem/{searchString}")]
        public IHttpActionResult SearchBookingSystem(string searchString)
        {
            var system = bookingSystemRepository.SearchBookingSystem(searchString);
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        [HttpGet]
        [Route("api/getBookingSystem/{id}")]
        public IHttpActionResult GetBookingSystem(int id)
        {
            var system = bookingSystemRepository.GetBookingSystem(id);
            if (system == null)
            {
                return BadRequest();
            }

            return Ok(system);
        }
        [HttpPost]
        [Route("api/addBookingSystem/")]
        public IHttpActionResult AddBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.AddBookingSystem(bookingSystem);
            return Ok();
        }

        [HttpPost]
        [Route("api/editBookingSystem/")]
        public IHttpActionResult EditBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.EditBookingSystem(bookingSystem);
            return Ok();
        }

        [HttpPost]
        [Route("api/deleteBookingSystem/")]
        public IHttpActionResult DeleteBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.DeleteBookingSystem(bookingSystem);
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}