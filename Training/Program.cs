using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// LocalRedirect
//app.Map("/old", () => Results.LocalRedirect("/new"));
//app.Map("/new", () => "New Address");

// Redirect
app.Map("/old", () => Results.Redirect("https://metanit.com"));
app.Map("/", () => "Hello World!");

app.Run();