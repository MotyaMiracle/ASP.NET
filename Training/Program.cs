var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map(
    "/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
    (string name, int age) => $"User Age: {age} \nUser Name:{name}"
);
app.Map(
    "/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}/",
    (string phone) => $"Phone: {phone}"
);
app.Map("/", () => "Index Page");

app.Run();
