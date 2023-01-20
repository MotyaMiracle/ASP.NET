var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("config.json");
app.Map("/", (IConfiguration appConfig) =>
{
    IConfigurationSection connString = appConfig.GetSection("ConnectionStrings");
    string defaultString = connString.GetSection("DefaultConnection").Value;
    //string defaultConnection = appConfig.GetSection("ConnectionStrings:DefaultConnection").Value; // можно так
    //string defaultConnection = appConfig["ConnectionStrings:DefaultConnection"];
    string con = appConfig.GetConnectionString("DefaultConnection");

    return defaultString;
});



app.Run();
