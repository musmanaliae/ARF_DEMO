using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARF_Models;

namespace ARF_Data
{
     
   public class FlightDailySchedule
    {
        public DateTime FlightDate = new DateTime();
        public List<Flight> DailyFlights = new List<Flight>();

        public FlightDailySchedule(DateTime flightDate)
        {
            FlightDate = flightDate;
            DailyFlights = new List<Flight>();
            DailyFlights.Add(new Flight("Pk101", "07:00", 25,"MEL", "SYD"));
            DailyFlights.Add(new Flight("Pk102", "12:00", 25,"SYD","MEL"));
            DailyFlights.Add(new Flight("Pk103", "16:00", 25,"MEL","ADL"));
            DailyFlights.Add(new Flight("Pk104", "19:00", 25,"ADL", "MEL"));
        }

        public FlightDailySchedule()
        {
            DailyFlights = new List<Flight>();
            DailyFlights.Add(new Flight("Pk101", "07:00", 25, "MEL", "SYD"));
            DailyFlights.Add(new Flight("Pk102", "12:00", 25, "SYD", "MEL"));
            DailyFlights.Add(new Flight("Pk103", "16:00", 25, "MEL", "ADL"));
            DailyFlights.Add(new Flight("Pk104", "19:00", 25, "ADL", "MEL"));
        }

    }
}
