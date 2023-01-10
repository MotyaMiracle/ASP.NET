using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var responce = context.Response;
    var request = context.Request;

    responce.ContentType = "text/html; charset=utf-8";

    if (request.Path == "/upload" && request.Method == "POST")
    {
        IFormFileCollection files = request.Form.Files;
        // путь к папке, где будут храниться файлы
        var uploadPath = $"{ Directory.GetCurrentDirectory()}/uploads";
        // создаем папку для хранения файлов
        Directory.CreateDirectory(uploadPath);
        
        foreach(var file in files)
        {
            // путь к папке uploads
            string fullPath = $"{uploadPath}/{file.FileName}";

            // сохраняем файл в папку uploads
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
        await responce.WriteAsync("Файлы успешно загружены");
    }
    else
    {
        await responce.SendFileAsync("html/index.html");
    }
});

app.Run();