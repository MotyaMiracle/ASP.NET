var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// установка настроек конфигурации
app.Configuration["name"] = "Tom";
app.Configuration["age"] = "37";

app.Run(async context =>
{
    // получение настроек конфигурации
    string name = app.Configuration["name"];
    string age = app.Configuration["age"];
    await context.Response.WriteAsync($"{name} - {age}");
});

app.Run();
