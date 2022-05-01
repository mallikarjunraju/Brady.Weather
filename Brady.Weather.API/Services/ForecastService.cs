namespace Brady.Weather.API.Services
{
    using Brady.Weather.API.Entities;
    using Brady.Weather.API.Services.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
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
        /// <returns></returns>
        public async Task<ApiResponse<List<ForecastData>>> GetCityForecast(string city)
        {
            var forecastData = new List<ForecastData>();
            var coordinates = _geoCodingService.GetCityCoordinates(city);
            if (coordinates != null && coordinates.Result !=null)
            {
                var response = await _client.GetAsync($"data/2.5/onecall?appid={_configuration.GetSection("OpenWeatherMap:Key").Value}&lat={coordinates.Result.Latitude}&lon={coordinates.Result.Longitude}&exclude=minutely,hourly,alerts&units=metric");
                var jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);

                if (response.IsSuccessStatusCode)
                {
                    foreach (var item in jsonResponse["daily"])
                    {
                        forecastData.Add(new ForecastData
                        {
                            Date = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(item["dt"]?.Value<string>())).ToString("dddd, dd MMMM yyyy"),
                            Desc = item["weather"][0]["description"]?.Value<string>(),
                            FeelsLike = new ShiftsTemperature
                            {
                                DayTemp = item["feels_like"]["day"].Value<string>(),
                                EveningTemp = item["feels_like"]["eve"].Value<string>(),
                                MorningTemp = item["feels_like"]["eve"].Value<string>(),
                                NightTemp = item["feels_like"]["night"].Value<string>()
                            },
                            ForecastTemp = new ForecastTemperature
                            {
                                MaxTemp = item["temp"]["day"].Value<string>(),
                                MinTemp = item["temp"]["day"].Value<string>(),
                                ShiftsTemp = new ShiftsTemperature
                                {
                                    DayTemp = item["temp"]["day"].Value<string>(),
                                    EveningTemp = item["temp"]["eve"].Value<string>(),
                                    MorningTemp = item["temp"]["eve"].Value<string>(),
                                    NightTemp = item["temp"]["night"].Value<string>()
                                }
                            }
                        });
                    }

                    return new ApiResponse<List<ForecastData>> { Data = forecastData, IsSuccessResponse = response.IsSuccessStatusCode };
                }
                else
                {
                    return new ApiResponse<List<ForecastData>>
                    {
                        IsSuccessResponse = response.IsSuccessStatusCode,
                        Exception = new ApiException
                        {
                            Code = jsonResponse["cod"].Value<string>(),
                            Message = jsonResponse["message"].Value<string>()
                        }
                    };
                }
            }
            else
            {
                return new ApiResponse<List<ForecastData>>
                {
                    IsSuccessResponse = false,
                    Exception = new ApiException
                    {
                        Code = "400",
                        Message = "Enter a Valid City."
                    }
                };
            }
        }
    }
}
