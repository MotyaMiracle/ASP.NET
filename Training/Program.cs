using Microsoft.Extensions.FileProviders;
using System.Runtime.InteropServices.ComTypes;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    await context.Response.SendFileAsync("image.png");
    // Отправка html-страницы
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
    var path = context.Request.Path;
    var fullPath = $"html/{path}";
    var responce = context.Response;

    responce.ContentType = "text/html; charset=utf-8";
    if (File.Exists(fullPath))
        await responce.SendFileAsync(fullPath);
    else
    {
        responce.StatusCode = 404;
        await responce.WriteAsync("<h2>Not Found</h2>");
    }
    // Загрузка файла
    context.Response.Headers.ContentDisposition = "attachment; filename=image.png";
    await context.Response.SendFileAsync("image.png");
    // IFileInfo
    var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    var fileInfo = fileProvider.GetFileInfo("image.png");

    context.Response.Headers.ContentDisposition = "attachment; filename=image.png";
    await context.Response.SendFileAsync(fileInfo);
});

app.Run();