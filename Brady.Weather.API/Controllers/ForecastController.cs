namespace Brady.Weather.API.Controllers
{
    using Brady.Weather.API.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// ForecastController
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class ForecastController : ControllerBase
    {
        private readonly ILogger<ForecastController> _logger;
        private readonly IForecastService _forecastService;

        /// <summary>
        /// ForecastController Constructor.
        /// </summary>
        /// <param name="forecastService"></param>
        /// <param name="logger"></param>
        public ForecastController(IForecastService forecastService, ILogger<ForecastController> logger)
        {
            _forecastService = forecastService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the weather forecast data for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            var rawForecast = await this._forecastService.GetCityForecast(city);
            return Ok(rawForecast);
        }
    }
}
