namespace Brady.Weather.API.Middleware.ErrorHandling
{
    /// <summary>
    /// Error codes
    /// </summary>
    public static class ErrorCode
    {
        /// <summary>
        /// The internal server error
        /// </summary>
        public const string InternalServerError = "InternalServerError";

        /// <summary>
        /// The validation error
        /// </summary>
        public const string ValidationError = "ValidationError";

        /// <summary>
        /// The service unavailable error
        /// </summary>
        public const string ServiceUnavailableError = "ServiceUnavailableError";

        /// <summary>
        /// The not found error
        /// </summary>
        public const string NotFound = "NotFound";
    }
}