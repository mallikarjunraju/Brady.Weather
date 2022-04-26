namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using System.Collections.Generic;

    /// <summary>
    /// Error titles
    /// </summary>
    public static class ErrorTitles
    {
        private static Dictionary<string, string> titles = new Dictionary<string, string>()
        {
            [ErrorCode.ValidationError] = "Request validation failed",
            [ErrorCode.InternalServerError] = "Internal server error",
            [ErrorCode.ServiceUnavailableError] = "Service unavailable",
            [ErrorCode.NotFound] = "Resource not found"
        };

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Error title</returns>
        public static string GetTitle(string code)
        {
            return titles.TryGetValue(code, out var title) ? title : code;
        }
    }
}