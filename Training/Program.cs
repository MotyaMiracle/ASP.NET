using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICounter, RandomCounter>();
builder.Services.AddTransient<CounterService>();


var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();
