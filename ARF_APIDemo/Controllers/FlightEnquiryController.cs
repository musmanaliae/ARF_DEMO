using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARF_Data;
using ARF_Models;

namespace ARF_APIDemo.Controllers
{
    [RoutePrefix("api/FlightEnquiry")]    
    public class FlightEnquiryController : ApiController
    {
        /// <summary>
        /// /// Get method to get daily schedule of flights
        /// </summary>
        /// <returns></returns>
        [Route("GetDailySchedule")]
        [HttpGet]
        public List<Flight> GetDailyFlights()
        {
            FlightDailySchedule oDailyFlightSched = new FlightDailySchedule();
            return oDailyFlightSched.DailyFlights;
        }

        /// <summary>
        /// Get method to enquire about a flight 
        /// </summary>
        /// <param name="pax">Required pax</param>
        /// <param name="sFrom">From date</param>
        /// <param name="sEnd">To date</param>
        /// <param name="orig">Flight Origin</param>
        /// <param name="dest">Flight Destination</param>
        /// <returns></returns>
        [HttpGet]
        public List<FlightDailySchedule> Get(int pax, string sFrom, string sEnd, string orig, string dest)
        {
            
            DateTime dFrom = new DateTime();
            if (DateTime.TryParse(sFrom, out dFrom))
            {
                DateTime dTo = new DateTime();
                if (DateTime.TryParse(sEnd, out dTo))
                {
                    FlightEnquiry Enq = new FlightEnquiry();
                    List<FlightDailySchedule> lstEnq = Enq.GetFlights(pax, dFrom, dTo, orig, dest);
                    return lstEnq;
                
                }
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("End date is not in correct format")),
                    ReasonPhrase = "End Date not valid"
                };
                throw new HttpResponseException(resp);
            }
            var resp1 = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format("From date is not in correct format")),
                ReasonPhrase = "From Date not valid"
            };
            throw new HttpResponseException(resp1);
        }

        // POST api/<controller>
        [Route("BookFlight")]
        public HttpResponseMessage Post(FlightEnquiry oEnq)
        {
            var message = Request.CreateResponse(HttpStatusCode.Forbidden, oEnq);
            return message;
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            var message = Request.CreateResponse(HttpStatusCode.Forbidden, value);
            return message;
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            var message = Request.CreateResponse(HttpStatusCode.Forbidden, id);
            return message;
        }
    }
}