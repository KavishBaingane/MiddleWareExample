using MiddleWareExample.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleWare>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//middleware 1 
app.Use(async (HttpContext context, RequestDelegate next) =>
{
   await context.Response.WriteAsync("From MiddleWare 1 \n");
    await next(context);
});

//middleware 2
//app.UseMiddleware<MyCustomMiddleWare>();
app.UseHelloCustomMiddleware();
app.Run(async (context) =>
{
    await context.Response.WriteAsync("From MiddleWare 3 \n");
});

app.Run();
