var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("/hello", () => "Hello METANIT.COM");
//app.Map("/{message?}", (string? message) => $"Message: {message}");
app.Map("/{controller}/Index/5", (string controller) => $"Controller: {controller}");
app.Map("/Home/{action}/{id}", (string action) => $"Action: {action}");

app.Map("/", () => "Index Page");

app.Run();
