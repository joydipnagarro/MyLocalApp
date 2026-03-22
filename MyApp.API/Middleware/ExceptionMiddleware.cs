using System.Net;
using MyApp.API.Models;

namespace MyApp.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    Message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}