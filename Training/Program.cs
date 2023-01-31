using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Send text and method Content
//app.Map("/", () => Results.Content("你好", "text/plain", System.Text.Encoding.Unicode));
//app.Map("/", () => Results.Content("Hello ASP.NET Core"));

// Text
//app.Map("/chinese", () => Results.Text("你好", "text/plain", System.Text.Encoding.Unicode));
//app.Map("/", () => Results.Text("Hello World"));

// Send JSON
//app.Map("/person", () => Results.Json(new Person("Bob", 41))); // send object Person
//app.Map("/", () => Results.Json(new { Name = "Tom", Age = 32 })); // send anon object
app.Map("/sam", () => Results.Json(new Person("Sam", 25), new()
{
    PropertyNameCaseInsensitive = false,
    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString
}));

app.Map("/bob", () => Results.Json(new Person("Bob", 41), 
    new(System.Text.Json.JsonSerializerDefaults.Web)));

app.Map("/tom", () => Results.Json(new Person("Tom", 32),
    new(System.Text.Json.JsonSerializerDefaults.General)));
app.Run();

app.Map("/error", () => Results.Json(new { message="Unexpected error" }, statusCode: 500));

app.Map("/", () => "Hello World!");
record class Person(string Name, int Age);
