var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration
    .AddJsonFile("config.json")
    .AddXmlFile("config.xml")
    .AddIniFile("config.ini")
    .AddInMemoryCollection(new Dictionary<string, string>
{
    { "name", "Sam"},
    { "age", "32"}
}); ;

app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
