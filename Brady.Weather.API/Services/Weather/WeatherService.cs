﻿namespace Brady.Weather.API.Services.OpenWeatherMap
{
    using Microsoft.Extensions.Configuration;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// OpenWeatherAppService
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// OpenWeatherAppService Constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="configuration"></param>
        public WeatherService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        /// <summary>
        /// Gets the weather data for a given city.
        /// </summary>
        /// <param name="city">City Name.</param>
        /// <returns></returns>
        public async Task<string> GetCityWeather(string city)
        {
            var response = await _client.GetAsync($"{_configuration.GetSection("OpenWeatherMap:Version").Value}/weather?appid={_configuration.GetSection("OpenWeatherMap:Key").Value}&q={city}");
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }           
        }
    }
}