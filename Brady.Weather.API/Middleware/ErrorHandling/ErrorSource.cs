namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error source
    /// </summary>
    public class ErrorSource
    {
        /// <summary>
        /// Gets or sets the pointer.
        /// </summary>
        /// <value>
        /// The pointer.
        /// </value>
        [JsonProperty(PropertyName = "pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string? Pointer { get; set; }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        [JsonProperty(PropertyName = "parameter", NullValueHandling = NullValueHandling.Ignore)]
        public string? Parameter { get; set; }
    }
}