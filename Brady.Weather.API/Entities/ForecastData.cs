namespace Brady.Weather.API.Entities
{
    /// <summary>
    /// ForecastData.
    /// </summary>
    public class ForecastData
    {
        /// <summary>
        /// Gets or sets the Date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the Temperature.
        /// </summary>
        public ForecastTemperature ForecastTemp { get; set; }

        /// <summary>
        /// Gets or sets the FeelsLike.
        /// </summary>
        public ShiftsTemperature FeelsLike { get; set; }

        /// <summary>
        /// Gets or sets the Desc.
        /// </summary>
        public string Desc { get; set; }
    }
}
