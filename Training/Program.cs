using Training;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Configuration.AddJsonFile("person.json");
//var tom = new Person();
//Person tom = app.Configuration.Get<Person>(); // ����� ��� ����� �� �������� �������������� ������ ������
//app.Configuration.Bind(tom);
//app.Run(async context => await context.Response.WriteAsync($"{tom.Name} - {tom.Age}"));

//app.Map("/", (IConfiguration appConfig) =>
//{
//    var tom = app.Configuration.Get<Person>(); // ��������� ������������ � �������� tom
//    return $"{tom.Name} - {tom.Age}";
//});

var tom = new Person();
app.Configuration.Bind(tom);

app.Run(async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    string name = $"<p>Name: {tom.Name}</p>";
    string age = $"<p>Age: {tom.Age}</p>";
    string company = $"<p>Company: {tom.Company?.Title}</p>";
    string langs = $"<p>Languages:</p><ul>";
    foreach (var lang in tom.Languages)
    {
        langs += $"<li><p>{lang}</p></li>";
    }
    langs += "</ul>";
    await context.Response.WriteAsync($"{name}{age}{company}{langs}");
});


app.Run();
