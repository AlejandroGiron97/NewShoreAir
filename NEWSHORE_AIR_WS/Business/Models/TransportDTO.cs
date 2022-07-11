using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class TransportDTO
    {
        public string FlightCarrier { get; set; }
        public string FlightNumber{get;set;}

        internal TransportDTO(Transport transport) 
        {
            FlightCarrier = transport.FlightCarrier;
            FlightNumber = transport.FlightNumber;
        }
        public TransportDTO() { }

    }


}
