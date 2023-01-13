using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IHelloService, RuHelloService>();
builder.Services.AddTransient<IHelloService ,EnHelloService>();

var app = builder.Build();

app.UseMiddleware<HelloMiddleware>();

app.Run();
