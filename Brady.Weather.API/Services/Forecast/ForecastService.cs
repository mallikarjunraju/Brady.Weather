namespace Brady.Weather.API.Services.Forecast
{
    using Brady.Weather.API.Services.GeoCoding;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// ForecastService.
    /// </summary>
    public class ForecastService : IForecastService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IGeoCodingService _geoCodingService;
        /// <summary>
        /// ForecastService Constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        /// <param name="geoCodingService"></param>
        public ForecastService(HttpClient client, IConfiguration configuration, IGeoCodingService geoCodingService)
        {
            _client = client;
            _configuration = configuration;
            _geoCodingService = geoCodingService;
        }
        /// <summary>
        /// Gets the weather forecast data for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public async Task<string> GetCityForecast(string city)
        {
            var coordinates = _geoCodingService.GetCityCoordinates(city);
            var response = await _client.GetAsync($"data/2.5/onecall?appid={_configuration.GetSection("OpenWeatherMap:Key").Value}&lat={coordinates.Result.Latitude}&lon={coordinates.Result.Longitude}&exclude=minutely,hourly,alerts");
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }
            return null;
        }
    }
}
