using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class JourneyDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
        public IEnumerable<FlightDTO> flights { get; set; }

        internal JourneyDTO(Journey journey) 
        {
            this.Origin = journey.Origin;
            this.Destination = journey.Destination;
            this.Price = journey.Price;
            this.flights = journey.flights.Select(f => new FlightDTO(f));
        }
        public JourneyDTO() { }
    }

}
