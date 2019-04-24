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

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/recBookingSystem")]
        public IHttpActionResult RecBookingSystem(BookingSystem bookingSystem)
        {


            return Ok("WOwww");
        }
        [HttpGet]
        [Route("api/getBookingSystem/{id}")]
        public async Task<IHttpActionResult> GetBookingSystemAsync(int id)
        {
            var system = await bookingSystemRepository.GetBookingSystem(id);
            if (system == null)
            {
                return BadRequest();
            }
                       
            return Ok(system);
        }
        [HttpPost]
        [Route("api/addBookingSystem/")]
        public async Task <IHttpActionResult> AddBookingSystem(BookingSystem bookingSystem/*, HttpPostedFileBase upload*/)
        {
            new BookingSystemRepository().AddBookingSystem(bookingSystem/*, upload*/);
            return Ok();
        }

        [HttpPost]
        [Route("api/editBookingSystem/")]
        public async Task<IHttpActionResult> EditBookingSystem(BookingSystem bookingSystem)
        {
            new BookingSystemRepository().EditBookingSystem(bookingSystem);
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