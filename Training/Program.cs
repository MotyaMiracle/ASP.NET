var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Creating factory
//ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
//ILogger logger = loggerFactory.CreateLogger<Program>();

//app.Run(async context =>
//{
//    logger.LogInformation($"Requested Path: {context.Request.Path}");
//    await context.Response.WriteAsync("Hello World!");
//});

// Getting a logger factory through dependency injection
//app.Map("/hello", (ILoggerFactory loggerFactory) =>
//{
//    // создаем логгер с категорией "MapLogger"
//    ILogger logger = loggerFactory.CreateLogger("MapLogger");
//    // логгируем некоторое сообщение
//    logger.LogInformation($"Path: /hello Time: {DateTime.Now.ToLongTimeString()}");
//    return "Hello world!";
//});

// Logging providers
ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
ILogger logger = loggerFactory.CreateLogger<Program>();
app.Run(async context =>
{
    logger.LogInformation($"Requested Path: {context.Request.Path}");
    await context.Response.WriteAsync("Hello World!");
});
app.Run();
