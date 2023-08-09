using Microsoft.AspNetCore.Http;

namespace GrabIt.Infrastructure.MiddleWare
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }
            catch (Exception e)
            {

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(
                    new
                    {
                        StatusCode = 500,
                        e.Message
                    }
                );


            }


        }
    }
}