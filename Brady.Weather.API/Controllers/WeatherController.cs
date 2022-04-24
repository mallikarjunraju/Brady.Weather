namespace Brady.Weather.API.Controllers
{
    using Brady.Weather.API.Services.Weather;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// WeatherController.
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        /// <summary>
        /// WeatherController Constructor.
        /// </summary>
        /// <param name="weatherService"></param>
        /// <param name="logger"></param>
        public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the weather data for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            try
            {
                var rawWeather = await this._weatherService.GetCityWeather(city);
                return Ok(rawWeather);
            }
            catch (HttpRequestException httpRequestException)
            {
                _logger.LogError($"Exception in Weather API: {httpRequestException}");
                return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
            }
        }
    }
}
