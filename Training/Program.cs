using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

//string date = "";

//app.Use(async (context, next) =>
//{
//    date = DateTime.Now.ToShortDateString();
//    //await next.Invoke(); // объект HttpContext и делегат Func<Task>
//    await next.Invoke(context); // здесь next - RequestDelegate
//    Console.WriteLine($"Current date: {date}");

//});

//app.Run(async(context) => await context.Response.WriteAsync($"Date: {date}"));
app.Use(GetDate);
app.Run(async (context) => await context.Response.WriteAsync($"Hello METANIT.COM"));

app.Run();
async Task GetDate(HttpContext context, Func<Task> next)
{
    string? path = context.Request.Path.Value?.ToLower();
    if (path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
        //await next.Invoke(context); // используется делегат RequestDelegate
    }
}