var builder = WebApplication.CreateBuilder(args);

IServiceCollection allServices = builder.Services; // ��������� ��������

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
