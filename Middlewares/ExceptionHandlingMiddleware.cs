using DeskFlow.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;



namespace DeskFlow.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)//global unhandled exception catcher
            {
                Console.WriteLine("🚨 An unhandled exception occurred while processing request\n" + ex.InnerException);//wriites the exception in the console for debbuging purposes
                context.Response.StatusCode = 500;
                var response = new ErrorDto("A unexpected server error has occurred. Try again later, or now.");
                await context.Response.WriteAsJsonAsync(response);//json response that doesn't leak the stack
            }
        }
    }
}