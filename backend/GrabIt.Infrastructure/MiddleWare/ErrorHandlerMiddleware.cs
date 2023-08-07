namespace GrabIt.Infrastructure.MiddleWare
{
    public class ErrorHandlerMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}