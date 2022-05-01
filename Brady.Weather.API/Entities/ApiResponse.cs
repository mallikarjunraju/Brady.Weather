namespace Brady.Weather.API.Entities
{
    /// <summary>
    /// Generic API response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets IsSuccessResponse.
        /// </summary>
        public bool IsSuccessResponse {get;set;}

        /// <summary>
        /// Gets or sets Response Data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets Response Exception.
        /// </summary>
        public ApiException Exception { get; set; }
    }
}
