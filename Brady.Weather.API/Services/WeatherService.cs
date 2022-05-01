namespace Brady.Weather.API.Services.Weather
{
    using Brady.Weather.API.Entities;
    using Brady.Weather.API.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
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
        public async Task<ApiResponse<WeatherData>> GetCityWeather(string city)
        {
            var response = await _client.GetAsync($"data/2.5/weather?appid={_configuration.GetSection("OpenWeatherMap:Key").Value}&q={city}&units=metric");
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);

            if (response.IsSuccessStatusCode)
            {
                var weatherResponse = new ApiResponse<WeatherData>
                {
                    IsSuccessResponse = response.IsSuccessStatusCode,
                    Data = new WeatherData
                    {
                        City = jsonResponse["name"].Value<string>(),
                        CurrentTemp = jsonResponse["main"]["temp"].Value<string>(),
                        Desc = jsonResponse["weather"][0]["description"].Value<string>(),
                        FeelsLike = jsonResponse["main"]["feels_like"].Value<string>(),
                        Humidity = jsonResponse["main"]["humidity"].Value<string>(),
                        Pressure = jsonResponse["main"]["pressure"].Value<string>(),
                        TempMax = jsonResponse["main"]["temp_max"].Value<string>(),
                        TempMin = jsonResponse["main"]["temp_min"].Value<string>()
                    }
                };                
                return weatherResponse;
            }

            else
            {
                var weatherResponse = new ApiResponse<WeatherData>
                {
                    IsSuccessResponse = response.IsSuccessStatusCode,
                    Exception = new ApiException
                    {
                        Code = "400",
                        Message = "Enter a Valid City."
                    }
                };
                return weatherResponse;
            }
        }
    }
}
