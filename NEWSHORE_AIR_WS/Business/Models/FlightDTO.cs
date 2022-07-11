using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class FlightDTO
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public string flightCarrier { get; set; }
        public string flightNumber { get; set; }
        public double price { get; set; }
        public TransportDTO transport { get; set;}

        internal FlightDTO(Flight flight) 
        {
            this.departureStation = flight.Origin;
            this.arrivalStation = flight.Destination;
            this.flightCarrier = flight.transport.FlightCarrier;
            this.flightNumber = flight.transport.FlightNumber;
            this.price = flight.Price;
            this.transport = new TransportDTO(flight.transport);


        }
        public FlightDTO() { }
    }

}
