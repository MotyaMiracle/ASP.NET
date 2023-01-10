using Microsoft.Extensions.FileProviders;
using System.ComponentModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;
using Training;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    if(request.Path == "/api/user")
    {
        var responseText = "Неккоректные данные"; // Содержит сообщения по умолчанию
        if (request.HasJsonContentType())
        {
            // определяем параметры сериализации/десериализации
            var jsonoptions = new JsonSerializerOptions();
            // добавляем конвертер кода json в объект типа Person
            jsonoptions.Converters.Add(new PersonConverter());
            // десериализуем данные с помощью конвертера PersonConverter
            var person = await request.ReadFromJsonAsync<Person>(jsonoptions);
            if (person != null)
                responseText = $"Name: {person.Name}  Age: {person.Age}";
        }
        await response.WriteAsJsonAsync(new { text = responseText });
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }






    //Person tom = new Person("Tom", 22);
    //await context.Response.WriteAsJsonAsync(tom);
});

app.Run();