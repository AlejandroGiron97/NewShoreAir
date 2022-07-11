using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Implementations;
using Business.Interfaces;
using Business.Models;
using Business.Exceptions;

namespace NewShore_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private IJourneyGetter journeyGetter;

        public FlightController(IJourneyGetter journeyGetter)
        {
            this.journeyGetter = journeyGetter;
        }

        [HttpGet(Name = "GetFlights")]
        public async Task<ActionResult> GetFlights(string origin, string destination)
        {
            try
            {
                return Ok(await journeyGetter.GetJourney(origin, destination));
            }
            catch (JourneyNotFoundException ex)
            {
                return BadRequest("could not find flights from origin to destination");
            }
        }
    }
}
