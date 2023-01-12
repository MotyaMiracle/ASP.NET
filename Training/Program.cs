using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<ITimeService, ShortTimeService>();

var app = builder.Build();

app.Run(async context =>
{
    //var timeService = context.RequestServices.GetService<ITimeService>(); Можно так
    var timeService = app.Services.GetService<ITimeService>();
    await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
});

app.Run();
