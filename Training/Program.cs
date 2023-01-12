using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<ITimeService, LongTimeService>();
builder.Services.AddTransient<TimeService>();

var app = builder.Build();

app.Run(async context =>
{
    //var timeService = app.Services.GetRequiredService<ITimeService>();
    var timeService = app.Services.GetRequiredService<TimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
