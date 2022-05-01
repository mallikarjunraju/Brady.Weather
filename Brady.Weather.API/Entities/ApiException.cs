namespace Brady.Weather.API.Entities
{
    /// <summary>
    /// ApiException.
    /// </summary>
    public class ApiException
    {
        /// <summary>
        /// Gets or sets Code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        public string Message { get; set; }
    }
}