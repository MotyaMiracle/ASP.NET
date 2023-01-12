using System.Text;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services; // Коллекция сервисов

builder.Services.AddMvc();

var app = builder.Build();


app.Run();
