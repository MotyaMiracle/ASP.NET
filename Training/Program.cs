//string[] commandLineArgs = { "name=Alice", "age=29" }; // ��������������� ��������� ������
var builder = WebApplication.CreateBuilder();
string[] commandLineArgs = { "name=Sam", "age=25" };
builder.Configuration.AddCommandLine(commandLineArgs); // �������� ��������� � �������� ������������

var app = builder.Build();

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
