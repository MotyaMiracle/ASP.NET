var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/date")
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    else
        await next.Invoke();
});

app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");

app.Run();
