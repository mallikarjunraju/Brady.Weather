namespace Brady.Weather.API.Middleware.ErrorHandling
{
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Exception handling middleware
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private readonly ILogger<ErrorHandlingMiddleware> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlingMiddleware" /> class.
        /// </summary>
        /// <param name="next">Next middleware handle</param>
        /// <param name="logger">The logger.</param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Invoke action</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                //// when caller aborts request runtime throws this exception
            }
            catch (HttpListenerException ex) when (ex.Message == "An operation was attempted on a nonexistent network connection")
            {
                //// when caller aborts request while any of the components are writing to the response stream
            }
            catch (Exception ex)
            {
                await this.HandleException(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            this.logger.LogError($"Exception:{ex}");

            if (context.Response != null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                if (context.Response.Body != null && context.Response.Body.CanWrite)
                {
                    var responseContent =
                        JsonConvert.SerializeObject(new { errors = new[] { new ErrorModel(ErrorCode.InternalServerError) } });
                    await context.Response.WriteAsync(responseContent);
                }
            }
        }
    }
}
