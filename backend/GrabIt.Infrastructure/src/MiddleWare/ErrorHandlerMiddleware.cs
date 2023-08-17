using GrabIt.Service.ErrorHandler;
using Microsoft.EntityFrameworkCore;

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
            catch (ErrorHandlerService e)
            {
                context.Response.StatusCode = e.StatusCode;

                await context.Response.WriteAsJsonAsync(e.Message);

            }
            catch (DbUpdateException e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(e.InnerException!.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync("Internal server error");
            }
        }
    }
}