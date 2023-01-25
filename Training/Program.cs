using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

var app = builder.Build();

app.Run(async (context) =>
{
    app.Logger.LogInformation($"Path: {context.Request.Path}  Time:{DateTime.Now.ToLongTimeString()}");
    await context.Response.WriteAsync("Hello World!");
});

app.Run();
