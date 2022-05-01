namespace Brady.Weather.API.Entities
{
    /// <summary>
    /// WeatherData.
    /// </summary>
    public class WeatherData
    {
        /// <summary>
        /// Gets or sets the weather description.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Gets or sets the City name.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the Current Temp.
        /// </summary>
        public string CurrentTemp { get; set; }

        /// <summary>
        /// Gets or sets the Feels Like.
        /// </summary>
        public string FeelsLike { get; set; }

        /// <summary>
        /// Gets or sets the Minimum Temperature.
        /// </summary>
        public string TempMin { get; set; }

        /// <summary>
        /// Gets or sets the Maximum Temperature.
        /// </summary>
        public string TempMax { get; set; }

        /// <summary>
        /// Gets or sets the Pressure.
        /// </summary>
        public string Pressure { get; set; }

        /// <summary>
        /// Gets or sets the Humidity.
        /// </summary>
        public string Humidity { get; set; }
    }
}
