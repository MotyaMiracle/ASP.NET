var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// StatusCode
app.Map("/about", () => Results.StatusCode(401));

// NotFound
app.Map("/contacts", () => Results.NotFound(new { message = "Resource Not Found" }));
app.Map("/address", () => Results.NotFound("Error 404. Invalid address"));

// Unauthorized
app.Map("/acc", () => Results.Unauthorized());
app.Map("/", () => "Hello World!");

// BadRequest
app.Map("/content/{age:int}", (int age) =>
{
    if (age < 18)
        return Results.BadRequest(new { message = "Invalid age" });
    else
        return Results.Content("Access is available");
});

// Ok
app.Map("/car", () => Results.Ok("Lamborgini"));
app.Map("/access", () => Results.Ok(new { message = "Success!" }));

app.Run();