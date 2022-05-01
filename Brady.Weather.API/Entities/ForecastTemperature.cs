namespace Brady.Weather.API.Entities
{
    /// <summary>
    /// ForeCastTemperature.
    /// </summary>
    public class ForecastTemperature
    {
        /// <summary>
        /// Gets or sets the Min Temperature.
        /// </summary>
        public string MinTemp { get; set; }

        /// <summary>
        /// Gets or sets the Max Temperature.
        /// </summary>
        public string MaxTemp { get; set; }

        /// <summary>
        /// Gets or sets the Shifts Temperature.
        /// </summary>
        public ShiftsTemperature ShiftsTemp { get; set; }
    }
}
