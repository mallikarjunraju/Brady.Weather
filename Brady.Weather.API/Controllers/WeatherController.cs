namespace Brady.Weather.API.Controllers
{
    using Brady.Weather.API.Services.OpenWeatherMap;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// WeatherForecastController
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _openWeatherAppService;

        /// <summary>
        /// WeatherForecastController Constructor.
        /// </summary>
        /// <param name="openWeatherAppService"></param>
        /// <param name="logger"></param>
        public WeatherController(IWeatherService openWeatherAppService, ILogger<WeatherController> logger)
        {
            _openWeatherAppService = openWeatherAppService;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            try
            {
                var rawWeather = await this._openWeatherAppService.GetCityWeather(city);
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
