using System.Xml.Linq;
using Training;

// initial data
List<Person> users = new List<Person>
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/users", () => users);

app.MapGet("/api/users/{id}", (string id) =>
{
    // get user by id
    Person? user = users.FirstOrDefault(u => u.Id == id);
    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // if the user is found, send it
    return Results.Json(user);
});

app.MapDelete("/api/users/{id}", (string id) =>
{
    // get user by id
    Person? user = users.FirstOrDefault(u => u.Id == id);

    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // if the user is found, delete it
    users.Remove(user);
    return Results.Json(user);
});

app.MapPost("/api/users", (Person user) => {

    // set id for new user
    user.Id = Guid.NewGuid().ToString();
    // add the user to the list
    users.Add(user);
    return user;
});

app.MapPut("/api/users", (Person userData) => {

    // get user by id
    var user = users.FirstOrDefault(u => u.Id == userData.Id);
    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });
    // if the user is found, change his data and send it back to the client

    user.Age = userData.Age;
    user.Name = userData.Name;
    return Results.Json(user);
});

app.Run();