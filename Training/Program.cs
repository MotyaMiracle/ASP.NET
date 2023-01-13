using System.Text;
using Training;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IHelloService, RuHelloService>();
//builder.Services.AddTransient<IHelloService ,EnHelloService>();

builder.Services.AddSingleton<ValueStorage>();
builder.Services.AddSingleton<IGenerator>(serv => serv.GetRequiredService<ValueStorage>());
builder.Services.AddSingleton<IReader>(serv => serv.GetRequiredService<ValueStorage>());

// Alternate
//var valueStorage = new ValueStorage();
//builder.Services.AddSingleton<IGenerator>(_ => valueStorage);
//builder.Services.AddSingleton<IReader>(_ => valueStorage);

var app = builder.Build();

//app.UseMiddleware<HelloMiddleware>();
app.UseMiddleware<GeneratorMiddleware>();
app.UseMiddleware<ReaderMiddleware>();

app.Run();
