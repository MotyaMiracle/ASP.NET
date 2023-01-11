using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//app.Environment.EnvironmentName = "Production"; // ����������� ��������� �������� �����
// ����� � � ����� launchSettings.json
app.Environment.EnvironmentName = "Test"; // �������� �������� ����� �� Test

if (app.Environment.IsEnvironment("Test")) // ���� ������ � ��������� "Test"
{
    app.Run(async (context) => await context.Response.WriteAsync("In Test Stage"));
}
else
{
    app.Run(async (context) => await context.Response.WriteAsync("In Development or Production Stage"));
}
Console.WriteLine($"{app.Environment.EnvironmentName}");

app.Run();