var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// ��������� ������� ����� ��������� ������������
//app.Map("/hello", (ILogger<Program> logger) =>
//{
//    logger.LogInformation($"Path: /hello Time: {DateTime.Now.ToLongTimeString()}");
//    return "Hello World!";
//});

// ������� ���� � ILogger
//app.Run(async context =>
//{
//    // ����� �� ������� ����������
//    app.Logger.LogInformation($"Processing request: {context.Request.Path}");

//    await context.Response.WriteAsync("Hello World!");
//});
// ������ � ������ ������������
app.Run(async (context) =>
{
    var path = context.Request.Path;
    app.Logger.LogCritical($"LogCritical {path}");
    app.Logger.LogError($"LogError {path}");
    app.Logger.LogInformation($"LogInformation {path}");
    app.Logger.LogWarning($"LogWarning {path}");

    await context.Response.WriteAsync("Hello World!");
});
app.Run();
