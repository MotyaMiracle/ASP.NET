var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Ќеоб€зательно ставить разделитель /, можно -- или and
//app.Map("/users/{id}/{name}", (string id, string name) => $"User id: {id}  User Name:{name}");
app.Map("/users/{id}/{name}", HandleRequest);
app.Map("/cars/{id?}", (string? id) => $"Car Id: {id ?? "Undefined"}");
app.Map("{controller=Home}/{action=Index}/{id?}", 
    (string controller, string action, string? id) =>
    $"Controller: {controller} \nAction: {action} \nId: {id}");
app.Map("products/{**info}", (string info) => $"Product Info: {info}");
app.Map("/users", () => "Users Page");
app.Map("/", () => "Index Page");

app.Run();

string HandleRequest(string id, string name)
{
    return $"User id: {id}  User Name:{name}";
}
