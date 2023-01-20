using Training;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//builder.Configuration.AddJsonFile("person.json");
//var tom = new Person();
//Person tom = app.Configuration.Get<Person>(); // можно так чтобы не создвать предварительно объект класса
//app.Configuration.Bind(tom);
//app.Run(async context => await context.Response.WriteAsync($"{tom.Name} - {tom.Age}"));

//app.Map("/", (IConfiguration appConfig) =>
//{
//    var tom = app.Configuration.Get<Person>(); // связываем конфигурацию с объектом tom
//    return $"{tom.Name} - {tom.Age}";
//});

//var tom = new Person();
//app.Configuration.Bind(tom);

//app.Run(async context =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    string name = $"<p>Name: {tom.Name}</p>";
//    string age = $"<p>Age: {tom.Age}</p>";
//    string company = $"<p>Company: {tom.Company?.Title}</p>";
//    string langs = $"<p>Languages:</p><ul>";
//    foreach (var lang in tom.Languages)
//    {
//        langs += $"<li><p>{lang}</p></li>";
//    }
//    langs += "</ul>";
//    await context.Response.WriteAsync($"{name}{age}{company}{langs}");
//});

//builder.Configuration.AddXmlFile("person.xml");

//var tom = new Person();
//app.Configuration.Bind(tom);

//app.Run(async context =>
//{
//    context.Response.ContentType = "text/html; charset=utf-8";
//    string name = $"<p>Name: {tom.Name}</p>";
//    string age = $"<p>Age: {tom.Age}</p>";
//    string company = $"<p>Company: {tom.Company?.Title}</p>";
//    string langs = $"<p>Languages:</p><ul>";
//    foreach (var lang in tom.Languages)
//    {
//        langs += $"<li><p>{lang}</p></li>";
//    }
//    langs += "</ul>";
//    await context.Response.WriteAsync($"{name}{age}{company}{langs}");
//});

builder.Configuration.AddJsonFile("person.json");

Company company = app.Configuration.GetSection("company").Get<Company>();

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"{company.Title} - {company.Country}");
});


app.Run();
