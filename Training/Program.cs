using Microsoft.Extensions.FileProviders;
using System.Runtime.InteropServices.ComTypes;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    if (context.Request.Path == "/old")
        //context.Response.Redirect("https://www.twitch.tv/"); // Но можно использовать редирект на внешние ресурсы
        context.Response.Redirect("/new");
    else if (context.Request.Path == "/new")
        await context.Response.WriteAsync("New Page");
    else
        await context.Response.WriteAsync("Main Page");
});

app.Run();