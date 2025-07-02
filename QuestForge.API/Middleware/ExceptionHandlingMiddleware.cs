using System.Net;
using System.Text.Json;
using QuestForge.Core.Exceptions;

namespace QuestForge.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                // Logging in the future
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, $"An unexpected error occurred, {ex.Message}");
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message, string? detail = null)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse((int)statusCode, message, detail);

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private class ErrorResponse
        {
            public int StatusCode { get; }
            public string Error { get; } = string.Empty;
            public string? Detail { get; }

            public ErrorResponse(int statusCode, string error, string? detail = null)
            {
                StatusCode = statusCode;
                Error = error;
                Detail = detail;
            }
        }
    }
}
