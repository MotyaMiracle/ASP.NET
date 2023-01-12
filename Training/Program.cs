using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICounter, RandomCounter>();
builder.Services.AddScoped<CounterService>();


var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();
