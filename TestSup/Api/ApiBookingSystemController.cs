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

        //Hämtar alla bokningssystem.
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
        
        //Hämtar bokningssystemen man söker på.
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

        //Hämtar ett bokningssystem.
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

        //Lägger till ett bokningssystem.
        [HttpPost]
        [Route("api/addBookingSystem/")]
        public IHttpActionResult AddBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.AddBookingSystem(bookingSystem);
            return Ok();
        }

        //Ändrar ett bokningssystem.
        [HttpPost]
        [Route("api/editBookingSystem/")]
        public IHttpActionResult EditBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.EditBookingSystem(bookingSystem);
            return Ok();
        }

        //Tar bort ett bokningssystem.
        [HttpPost]
        [Route("api/deleteBookingSystem/")]
        public IHttpActionResult DeleteBookingSystem(BookingSystem bookingSystem)
        {
            bookingSystemRepository.DeleteBookingSystem(bookingSystem);
            return Ok();
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån systemnamnen.
        [HttpGet]
        [Route("api/sortBookingSystemByName")]
        public IHttpActionResult SortBookingSystemByName()
        {
            var system = bookingSystemRepository.SortBookingSystemByName();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån kategori.
        [HttpGet]
        [Route("api/sortBookingSystemByCategory")]
        public IHttpActionResult SortBookingSystemByCategory()
        {
            var system = bookingSystemRepository.SortBookingSystemByCategory();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

        //Sorterar bokningsystemen i bokstavsordning utifrån stad.
        [HttpGet]
        [Route("api/sortBookingSystemByCity")]
        public IHttpActionResult SortBookingSystemByCity()
        {
            var system = bookingSystemRepository.SortBookingSystemByCity();
            if (system == null)
            {
                return BadRequest();
            }
            return Ok(system);
        }

    }
}