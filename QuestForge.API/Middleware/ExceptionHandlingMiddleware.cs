using System.Net;
using Microsoft.AspNetCore.Mvc;
using QuestForge.Domain.Common.Exceptions;

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
            catch (DomainException  ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                // Logging in the future
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, $"An unexpected error occurred, {ex.Message}");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message, string? detail = null)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails
            {
                Title = $"Invalid request: {message}",
                Status = (int)statusCode,
                Detail = detail,
                Instance = context.Request.Path
            };

            return context.Response.WriteAsJsonAsync(problem);
        }
    }
}
