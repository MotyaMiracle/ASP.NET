using System.Xml.Linq;
using Training;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// get the connection string from the config file
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// add the ApplicationContext as a service to the application
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));


var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

//app.MapGet("/api/users/{id}", (string id) =>
//{
//    // get user by id
//    User? user = users.FirstOrDefault(u => u.Id == id);
//    // if not found, send status code and error message
//    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

//    // if the user is found, send it
//    return Results.Json(user);
//});

//app.MapDelete("/api/users/{id}", (string id) =>
//{
//    // get user by id
//    User? user = users.FirstOrDefault(u => u.Id == id);

//    // if not found, send status code and error message
//    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

//    // if the user is found, delete it
//    users.Remove(user);
//    return Results.Json(user);
//});

//app.MapPost("/api/users", (User user) => {

//    // set id for new user
//    user.Id = Guid.NewGuid().ToString();
//    // add the user to the list
//    users.Add(user);
//    return user;
//});

//app.MapPut("/api/users", (User userData) => {

//    // get user by id
//    var user = users.FirstOrDefault(u => u.Id == userData.Id);
//    // if not found, send status code and error message
//    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });
//    // if the user is found, change his data and send it back to the client

//    user.Age = userData.Age;
//    user.Name = userData.Name;
//    return Results.Json(user);
//});

app.Run();