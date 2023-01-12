using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

RandomCounter rndCounter = new RandomCounter();
builder.Services.AddSingleton<ICounter>(rndCounter);
builder.Services.AddSingleton<CounterService>(new CounterService(rndCounter));


var app = builder.Build();

app.UseMiddleware<CounterMiddleware>();

app.Run();
