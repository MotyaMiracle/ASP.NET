using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITimeService, ShortTimeService>();
//builder.Services.AddTransient<TimeMessage>(); //Через конструктор

var app = builder.Build();

app.UseMiddleware<TimeMessageMiddleware>();

//app.Run(async context =>
//{
//var timeService = context.RequestServices.GetService<ITimeService>(); HttpContext.RequestServices
//var timeService = app.Services.GetService<ITimeService>();// Свойство Services объекта WebApplication
//await context.Response.WriteAsync($"Time: {timeService?.GetTime()}"); 
//var timeMessage = context.RequestServices.GetService<TimeMessage>(); //Через конструктор
//context.Response.ContentType = "text/html; charset=utf-8";
//await context.Response.WriteAsync($"<h2>{timeMessage?.GetTime()}</h2>");
//});

app.Run();
