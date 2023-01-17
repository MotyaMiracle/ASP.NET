var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Map("/", () => "Index Page");
app.Map("/about", () => "About Page");

app.Run(async context =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource not found");
});

app.Run();
