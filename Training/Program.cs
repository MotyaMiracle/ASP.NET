//string[] commandLineArgs = { "name=Alice", "age=29" }; // ��������������� ��������� ������
var builder = WebApplication.CreateBuilder();
//string[] commandLineArgs = { "name=Sam", "age=25" };
//builder.Configuration.AddCommandLine(commandLineArgs); // �������� ��������� � �������� ������������

var app = builder.Build();

builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
{
    {"name", "Tom"},
    {"age", "37"}
});

app.Map("/", (IConfiguration appConfig) =>
{
    var name = appConfig["name"];
    var age = appConfig["age"];
    return $"{name} - {age}";
});

//app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
