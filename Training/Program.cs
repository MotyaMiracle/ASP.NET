using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICounter, RandomCounter>();
builder.Services.AddSingleton<CounterService>();


var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();
