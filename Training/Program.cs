using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello METANIT.COM");
});

app.Run();
