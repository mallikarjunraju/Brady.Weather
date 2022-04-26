namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error model
    /// </summary>
    public class ErrorModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="title">The title.</param>
        /// <param name="detail">The detail.</param>
        public ErrorModel(string code, string? title = null, string? detail = null)
        {
            this.Code = code;
            this.Title = title;
            this.Detail = detail;
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        [JsonProperty(PropertyName = "detail", NullValueHandling = NullValueHandling.Ignore)]
        public string? Detail { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorSource? Source { get; set; }

        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>
        /// The meta.
        /// </value>
        [JsonProperty(PropertyName = "meta", NullValueHandling = NullValueHandling.Ignore)]
        public object? Meta { get; set; }
    }
}