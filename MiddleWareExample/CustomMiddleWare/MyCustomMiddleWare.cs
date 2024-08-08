
using System.Runtime.CompilerServices;

namespace MiddleWareExample.CustomMiddleWare
{
    public class MyCustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom MiddleWare - Starts \n");
            await next(context);
            await context.Response.WriteAsync("My Custom MiddleWare - Ends \n");
        }
    }
    public static class CustomMiddleWareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleWare>();
        }
    }
}
