
namespace MiddleWareExample.CustomMiddleWare
{
    public class MyCustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custome MiddleWare - Starts");
            await next(context);
            await context.Response.WriteAsync("My Custome MiddleWare - Ends");
        }
    }
}
