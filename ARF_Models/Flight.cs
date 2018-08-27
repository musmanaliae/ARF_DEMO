using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARF_Common;

namespace ARF_Models
{
    public class Flight
    {
        public string FlightNo { get; set; }

        public string FlightTime { get; set; }

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }

        public string Destination { get; set; }

        public string Origin { get; set; }
        
        public Flight(string flightno, string flighttime, int totalseats, string origin, string destination)
        {
            FlightNo = flightno;
            FlightTime = flighttime;
            TotalSeats = totalseats;
            Origin = origin;
            Destination = destination;

            AvailableSeats = RandomNumber.GenerateRandomNumber(3,7);
        }

        public Flight()
        { }
    }
}
