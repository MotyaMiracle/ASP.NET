using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapWhen(
    context => context.Request.Path == "/time", // если путь запроса "/time"
    appBuilder => appBuilder.Run(async context =>
    {
        var time = DateTime.Now.ToShortTimeString();
        await context.Response.WriteAsync($"Current time: {time}");
    }
));

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();