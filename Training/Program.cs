string[] commandLineArgs = { "name=Alice", "age=29" }; // ��������������� ��������� ������
var builder = WebApplication.CreateBuilder(commandLineArgs);


var app = builder.Build();

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
