var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
//{
//    {"name", "Tom" },
//    {"age", "37" }
//}!);

var app = builder.Build();

// ��������� �������� ������������
app.Configuration["name"] = "Tom";
app.Configuration["age"] = "37";

//app.Run(async context =>
//{
//    // ��������� �������� ������������
//    string name = app.Configuration["name"];
//    string age = app.Configuration["age"];
//    await context.Response.WriteAsync($"{name} - {age}");
//});
app.Map("/", (IConfiguration appConfig) => $"{appConfig["name"]} - {appConfig["age"]}");

app.Run();
