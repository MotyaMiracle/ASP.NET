using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITimer, Taimer>();
builder.Services.AddScoped<TimeService>();

var app = builder.Build();

app.UseMiddleware<TimerMiddleware>();

app.Run();
