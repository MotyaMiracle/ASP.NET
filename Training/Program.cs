var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

//builder.Configuration
//    .AddJsonFile("config.json");
//.AddJsonFile("otherconfig.json");

//app.Map("/", (IConfiguration appConfig) =>
//{
//    var personName = appConfig["person:profile:name"];
//    var companyName = appConfig["company:name"];
//    return $"{personName} - {companyName}";
//});
//builder.Configuration.AddXmlFile("config.xml");

//app.Map("/", (IConfiguration appConfig) =>
//{
//    var personName = appConfig["person:profile:name"];
//    var companyName = appConfig["company:name"];
//    return $"{personName} - {companyName}";
//});

builder.Configuration.AddIniFile("config.ini");

app.Map("/", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["company"]}");



app.Run();
