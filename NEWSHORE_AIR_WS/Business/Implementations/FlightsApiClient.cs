using Business.Interfaces;
using Business.Models;
using DataAccess;
using System.Net.Http.Json;

namespace Business.Implementations
{
    public class FlightsApiClient : IFlightsApiClient
    {
        private HttpClient _httpClient;

        public FlightsApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://recruiting-api.newshore.es/api/");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Flight>> GetAllFlights()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("flights/1");
            response.EnsureSuccessStatusCode();
            IEnumerable<ApiFlight>? apiFlights = await response.Content.ReadFromJsonAsync<IEnumerable<ApiFlight>>();
            if (apiFlights == null)
            {
                throw new HttpRequestException("could not extract flights");
            }
            return apiFlights.Select(apiFlight => apiFlight.ToFlight());
        }
    }
}