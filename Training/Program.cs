using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//app.Environment.EnvironmentName = "Production"; // Программная установка значения среды
// Можно и в файле launchSettings.json
app.Environment.EnvironmentName = "Test"; // изменяем название среды на Test

if (app.Environment.IsEnvironment("Test")) // Если проект в состоянии "Test"
{
    app.Run(async (context) => await context.Response.WriteAsync("In Test Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development or Production Stage"));
}
Console.WriteLine($"{app.Environment.EnvironmentName}");

app.Run();