using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flow.Infrastructure.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = exception switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError 
            };

            var errorResponse = new
            {
                message = exception.Message,
                statusCode = response.StatusCode
            };

            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
