using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;


var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseWhen(
    context => context.Request.Path == "/time", // если путь запроса "/time"
    HandTimeRequest
);

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();
void HandTimeRequest(IApplicationBuilder appBuilder) {

        // логгируем данные - выводим на консоль приложения
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next(); // вызываем следующий middleware
        });
 
}