namespace Brady.Weather.API.Services.Interfaces
{
    using Brady.Weather.API.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// IForecastService interface.
    /// </summary>
    public interface IForecastService
    {
        /// <summary>
        /// Gets the weather forecast data for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Task<ApiResponse<List<ForecastData>>> GetCityForecast(string city);
    }
}
