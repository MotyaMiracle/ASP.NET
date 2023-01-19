//string[] commandLineArgs = { "name=Alice", "age=29" }; // псевдопараметры командной строки
var builder = WebApplication.CreateBuilder();
string[] commandLineArgs = { "name=Sam", "age=25" };
builder.Configuration.AddCommandLine(commandLineArgs); // передаем параметры в качестве конфигурации

var app = builder.Build();

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
