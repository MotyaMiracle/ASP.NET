using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITimeService, LongTimeService>();

var app = builder.Build();

app.Run(async context =>
{
    var timeService = app.Services.GetRequiredService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
