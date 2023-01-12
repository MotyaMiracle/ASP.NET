using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<ITimeService, LongTimeService>();
//builder.Services.AddTransient<TimeService>();
builder.Services.AddTimeService();

var app = builder.Build();

app.Run(async context =>
{
    //var timeService = app.Services.GetRequiredService<ITimeService>();
    //var timeService = app.Services.GetRequiredService<TimeService>();
    var timeService = app.Services.GetService<TimeService>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
