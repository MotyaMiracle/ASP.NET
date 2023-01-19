var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

builder.Configuration
    .AddJsonFile("config.json");
    //.AddJsonFile("otherconfig.json");

app.Map("/", (IConfiguration appConfig) =>
{
    var personName = appConfig["person:profile:name"];
    var companyName = appConfig["company:name"];
    return $"{personName} - {companyName}";
});


app.Run();
