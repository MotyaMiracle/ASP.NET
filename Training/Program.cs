using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using Training;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//app.UseMiddleware<TokenMiddleware>(); // Если нет расширений
app.UseToken("55555");

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();