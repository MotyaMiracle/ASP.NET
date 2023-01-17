using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<TimeService>();

var app = builder.Build();

//app.Map("/time", (TimeService timeService) => $"Time: {timeService.Time}");
app.Map("/time", SendTime);
app.Map("/", () => "Hello METANIT.COM");

app.Run();

string SendTime(TimeService timeService)
{
    return $"Time: {timeService.Time}";
}