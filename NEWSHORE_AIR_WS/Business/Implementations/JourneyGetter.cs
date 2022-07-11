using Business.Exceptions;
using Business.Interfaces;
using Business.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class JourneyGetter : IJourneyGetter
    {
        Context _context;
        IFlightsApiClient _flightsApiClient;

        public JourneyGetter(Context context, IFlightsApiClient flightsApiClient)
        {
            _context = context;
            _flightsApiClient = flightsApiClient;
        }
        public async Task<JourneyDTO> GetJourney(string Origin, string Destination)
        {
            var journeyFlight = await GetAndStoreJourney(Origin, Destination);
            return new JourneyDTO(journeyFlight);
        }

        private async Task<Journey> GetAndStoreJourney(string Origin, string Destination)
        {
            var journey = _context
                .Journeys
                .Include(j => j.flights)
                .ThenInclude(flight => flight.transport)
                .FirstOrDefault(j => j.Origin == Origin && j.Destination == Destination); 

            if (journey == null)
            {
                var allFlights = await _flightsApiClient.GetAllFlights();
                IEnumerable<Flight>? journeyFlights = await GetJourneyFlights(Origin, Destination, allFlights);
                if (journeyFlights is null)
                {
                    throw new JourneyNotFoundException();
                }
                journey = new Journey()
                {
                    Origin = Origin,
                    Destination = Destination,
                    Price = journeyFlights.Sum(flight => flight.Price),
                    flights = journeyFlights.ToList(),
                };
                _context.Journeys.Add(journey);
                await _context.SaveChangesAsync();
            }
            return journey;
        }

        private async Task<IEnumerable<Flight>>? GetJourneyFlights(
            string Origin,
            string Destination,
            IEnumerable<Flight> flights)
        {
            if (Origin == Destination)
            {
                return Array.Empty<Flight>();
            }
            else
            {
                foreach (var flight in flights)
                {
                    if (Destination == flight.Destination)
                    {
                        var journeyFlights = await GetJourneyFlights(Origin, flight.Origin, flights);
                        if (journeyFlights != null)
                        {
                            return journeyFlights.Append(flight);
                        }
                    }
                }
                return null;
            }
        }
    }
}
