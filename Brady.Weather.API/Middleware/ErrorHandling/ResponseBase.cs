namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Response base model
    /// </summary>
    public abstract class ResponseBase
    {
        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        public bool HasError => this.Errors != null && this.Errors.Any();

        /// <summary>
        /// Gets or sets the error model.
        /// </summary>
        /// <value>
        /// The error model.
        /// </value>
        [JsonProperty(PropertyName = "errors", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ErrorModel>? Errors { get; set; }
    }
}