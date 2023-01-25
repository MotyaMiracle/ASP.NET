var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Получение логгера через внедрение зависимостей
//app.Map("/hello", (ILogger<Program> logger) =>
//{
//    logger.LogInformation($"Path: /hello Time: {DateTime.Now.ToLongTimeString()}");
//    return "Hello World!";
//});

// Ведение лога и ILogger
//app.Run(async context =>
//{
//    // пишем на консоль информацию
//    app.Logger.LogInformation($"Processing request: {context.Request.Path}");

//    await context.Response.WriteAsync("Hello World!");
//});
// Уровни и методы логгирования
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
