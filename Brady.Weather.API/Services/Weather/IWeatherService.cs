namespace Brady.Weather.API.Services.OpenWeatherMap
{
    using System.Threading.Tasks;

    public interface IWeatherService
    {
        public Task<string> GetCityWeather(string city);
    }
}
