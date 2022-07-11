using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ApiFlight
    {
        public string departureStation {get;set;}
        public string arrivalStation {get;set;}
        public string flightCarrier {get;set;}
        public string flightNumber {get;set;}
        public double price { get; set; }

        public Flight ToFlight()
        {
            return new Flight()
            {
                transport = new Transport()
                {
                    FlightCarrier = flightCarrier,
                    FlightNumber = flightNumber,
                },
                Origin = departureStation,
                Destination = arrivalStation,
                Price = price,
            };
        }
    }
}
