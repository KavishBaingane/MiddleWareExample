using MiddleWareExample.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleWare>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//middleware 1 
app.Use(async (HttpContext context, RequestDelegate next) =>
{
   await context.Response.WriteAsync("From MiddleWare One");
    await next(context);
});

//middleware 2
app.UseMiddleware<MyCustomMiddleWare>();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("From MiddleWare Three");
});

app.Run();
