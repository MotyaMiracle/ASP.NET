var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // add IDistributedMemoryCache
builder.Services.AddSession(); // adding session services

var app = builder.Build();

app.UseSession(); // adding middleware to work with sessions

app.Run(async context =>
{
    if (context.Session.Keys.Contains("name"))
        await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}");
    else
    {
        context.Session.SetString("name", "Tom");
        await context.Response.WriteAsync("Hello World!");
    }
});



app.Run();
