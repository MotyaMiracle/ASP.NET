using Training;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("person.json");
//var tom = new Person();
//Person tom = app.Configuration.Get<Person>(); // можно так чтобы не создвать предварительно объект класса
//app.Configuration.Bind(tom);
//app.Run(async context => await context.Response.WriteAsync($"{tom.Name} - {tom.Age}"));

app.Map("/", (IConfiguration appConfig) =>
{
    var tom = app.Configuration.Get<Person>(); // связываем конфигурацию с объектом tom
    return $"{tom.Name} - {tom.Age}";
});


app.Run();
