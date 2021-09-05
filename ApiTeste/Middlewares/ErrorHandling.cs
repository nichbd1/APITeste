using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ApiTeste.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;

        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new {
                success = false,
                message = exception.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            
            return context.Response.WriteAsync(result);
        }
    }
}
