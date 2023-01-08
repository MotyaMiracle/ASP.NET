var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) => 
{
    var response = context.Response;
    response.Headers.ContentLanguage = "ru-RU";
    response.Headers.ContentType = "text/plain; charset=uft-8";
    response.Headers.Append("secret-id", "256"); // добавление кастомного заголовка
    await response.WriteAsync("Hello METANIT.COM", System.Text.Encoding.Default);
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Resource Not Found");
    response.ContentType = "text/html; charset=utf-8";
    await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET</h3>");
});

app.Run();