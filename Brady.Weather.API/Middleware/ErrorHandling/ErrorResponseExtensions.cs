namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extensions related to error response model
    /// </summary>
    public static class ErrorResponseExtensions
    {
        /// <summary>
        /// Creates the error response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="code">The error code.</param>
        /// <param name="title">The title.</param>
        /// <param name="detail">The detail.</param>
        /// <returns>
        /// Response error model
        /// </returns>
        public static TResponse CreateErrorResponse<TResponse>(this string code, string? title = null, string? detail = null)
            where TResponse : ResponseBase
        {
            return new ErrorModel(code, title, detail).CreateErrorResponse<TResponse>();
        }

        /// <summary>
        /// Creates the error response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="errorModel">The error model.</param>
        /// <returns>
        /// Response error model
        /// </returns>
        public static TResponse CreateErrorResponse<TResponse>(this ErrorModel errorModel)
            where TResponse : ResponseBase
        {
            return new[] { errorModel }.CreateErrorResponse<TResponse>();
        }

        /// <summary>
        /// Creates the error response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="models">The models.</param>
        /// <returns>
        /// Response error model
        /// </returns>
        public static TResponse CreateErrorResponse<TResponse>(this IEnumerable<ErrorModel> models)
            where TResponse : ResponseBase
        {
            var response = Activator.CreateInstance<TResponse>();
            response.Errors = models;
            return response;
        }

        /// <summary>
        /// Creates the error response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="code">Type of the error.</param>
        /// <param name="validationMessages">The validation failures.</param>
        /// <param name="title">The title.</param>
        /// <returns>
        /// Response error model
        /// </returns>
        public static TResponse CreateErrorResponse<TResponse>(this string code, IEnumerable<string> validationMessages, string? title = null)
            where TResponse : ResponseBase
        {
            var failuresList = validationMessages as IList<string> ?? validationMessages?.ToList();

            if (failuresList == null || !failuresList.Any())
            {
                return code.CreateErrorResponse<TResponse>(title);
            }

            var errorModels = failuresList
                .Select(fail => new ErrorModel(code, title, fail));

            return errorModels.CreateErrorResponse<TResponse>();
        }
    }
}