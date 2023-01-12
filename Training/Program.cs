var builder = WebApplication.CreateBuilder(args);

IServiceCollection allServices = builder.Services; // Коллекция сервисов

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
