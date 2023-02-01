using System.Xml.Linq;
using Training;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// get the connection string from the config file
string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;

// add the ApplicationContext as a service to the application
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/users", async (ApplicationContext db) => await db.Users.ToListAsync());

app.MapGet("/api/users/{id:int}", async (int id, ApplicationContext db) =>
{
    // get user by id
    User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // if the user is found, send it
    return Results.Json(user);
});

app.MapDelete("/api/users/{id:int}", async(int id, ApplicationContext db) =>
{
    // get user by id
    User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });

    // if the user is found, delete it
    db.Users.Remove(user);
    await db.SaveChangesAsync();
    return Results.Json(user);
});

app.MapPost("/api/users", async(User user, ApplicationContext db) =>
{

    // add user to array
    await db.Users.AddAsync(user);
    await db.SaveChangesAsync();
    return user;
});

app.MapPut("/api/users", async(User userData, ApplicationContext db) =>
{

    // get user by id
    var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);
    // if not found, send status code and error message
    if (user == null) return Results.NotFound(new { message = "Пользователь не найден" });
    // if the user is found, change his data and send it back to the client

    user.Age = userData.Age;
    user.Name = userData.Name;
    await db.SaveChangesAsync();
    return Results.Json(user);
});

app.Run();