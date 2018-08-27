using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARF_Models;

namespace ARF_Data
{
    public class FlightEnquiry
    {
        /// <summary>
        /// 
        /// </summary>
        public List<FlightDailySchedule> lstFlights = new List<FlightDailySchedule>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dStart"></param>
        /// <param name="dEnd"></param>
        public void GenerateFlightData(DateTime dStart, DateTime dEnd)
        {
            lstFlights = new List<FlightDailySchedule>();
            int days = Convert.ToInt32((dEnd - dStart).TotalDays);

            for (int i = 0; i < days; i++)
            {
                FlightDailySchedule Flights = new FlightDailySchedule(dStart.AddDays(i));
                lstFlights.Add(Flights);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pax"></param>
        /// <param name="dStart"></param>
        /// <param name="dEnd"></param>
        /// <param name="Org"></param>
        /// <param name="Dest"></param>
        /// <returns></returns>
        public List<FlightDailySchedule> GetFlights(int Pax, DateTime dStart, DateTime dEnd, string Org, string Dest)
        { 
            GenerateFlightData( dStart,  dEnd);

            List<ARF_Data.FlightDailySchedule> lstEnq = this.lstFlights.Where(o => o.FlightDate >= dStart && o.FlightDate <= dEnd).ToList();


            IEnumerable<FlightDailySchedule> lstFlights =
            from p in lstEnq
            select new ARF_Data.FlightDailySchedule(p.FlightDate)
            {
                FlightDate = p.FlightDate,
                DailyFlights =
                (from f in p.DailyFlights
                 where f.AvailableSeats >= Pax
                       && f.Destination == Dest
                       && f.Origin == Org
                 select new Flight
                 {
                     AvailableSeats = f.AvailableSeats,
                     Destination = f.Destination,
                     FlightNo = f.FlightNo,
                     FlightTime = f.FlightTime,
                     Origin = f.Origin,
                     TotalSeats = f.TotalSeats
                 }
                 ).ToList()
            };

            lstFlights = lstFlights.Where(o => o.DailyFlights.Count > 0).ToList();

            return lstFlights.ToList();

        }
    }
}
