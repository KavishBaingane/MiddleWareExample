var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//middleware 1 
app.Use(async (HttpContext context, RequestDelegate next) =>
{
   await context.Response.WriteAsync("Hello");
    await next(context);
});

//middleware 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello again");
    await next(context);
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello twice");
});

app.Run();
