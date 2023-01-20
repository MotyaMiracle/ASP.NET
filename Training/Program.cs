using Training;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("person.json");
//var tom = new Person();
//Person tom = app.Configuration.Get<Person>(); // ����� ��� ����� �� �������� �������������� ������ ������
//app.Configuration.Bind(tom);
//app.Run(async context => await context.Response.WriteAsync($"{tom.Name} - {tom.Age}"));

app.Map("/", (IConfiguration appConfig) =>
{
    var tom = app.Configuration.Get<Person>(); // ��������� ������������ � �������� tom
    return $"{tom.Name} - {tom.Age}";
});


app.Run();
