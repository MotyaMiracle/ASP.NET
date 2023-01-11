using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Environment.EnvironmentName = "Production";

if (app.Environment.IsDevelopment())
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Production Stage"));
}
Console.WriteLine($"{app.Environment.EnvironmentName}");

app.Run();