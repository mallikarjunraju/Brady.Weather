namespace Brady.Weather.API.Services
{
    using Brady.Weather.API.Entities;
    using Brady.Weather.API.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// GeoCodingService.
    /// </summary>
    public class GeoCodingService : IGeoCodingService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// GeoCodingService Constructor.
        /// </summary>
        public GeoCodingService(HttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _configuration = configuration;
        }
        /// <summary>
        /// Gets the latitude and longitude for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<Coordinates> GetCityCoordinates(string city)
        {
            string lat = string.Empty, lon = string.Empty;

            var response = await _client.GetAsync($"geo/1.0/direct?appid={_configuration.GetSection("OpenWeatherMap:Key").Value}&q={city}&limit=5").ConfigureAwait(false);

            var jsonArray = JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);
            if (jsonArray != null)
            {
                lat = jsonArray[0]["lat"].Value<string>();
                lon = jsonArray[0]["lon"].Value<string>();
            }
            return await Task.FromResult(new Coordinates { Latitude = lat, Longitude = lon });
        }
    }
}
