namespace Brady.Weather.API.Services.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// IWeatherService interface.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Gets the weather data for a given city.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Task<string> GetCityWeather(string city);
    }
}
