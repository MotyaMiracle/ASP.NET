using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// adding authentication services
builder.Services.AddAuthentication("Bearer") // authentication scheme - using jwt tokens
    .AddJwtBearer(); // connect authentication using jwt tokens

var app = builder.Build();

app.UseAuthentication(); // add authentication middleware
app.UseAuthorization(); // adding authorization middleware

app.Map("/hello", [Authorize] () => "Hello World!");
app.Map("/", () => "Home Page");

app.Run();
