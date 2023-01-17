var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next.Invoke();

    if (context.Response.StatusCode == 404)
        await context.Response.WriteAsync("Resource Not Found");
});
app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");

app.Run();
