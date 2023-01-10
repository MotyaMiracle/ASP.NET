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
        // ���� � �����, ��� ����� ��������� �����
        var uploadPath = $"{ Directory.GetCurrentDirectory()}/uploads";
        // ������� ����� ��� �������� ������
        Directory.CreateDirectory(uploadPath);
        
        foreach(var file in files)
        {
            // ���� � ����� uploads
            string fullPath = $"{uploadPath}/{file.FileName}";

            // ��������� ���� � ����� uploads
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
        await responce.WriteAsync("����� ������� ���������");
    }
    else
    {
        await responce.SendFileAsync("html/index.html");
    }
});

app.Run();