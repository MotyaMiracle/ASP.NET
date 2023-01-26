using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(); // add IDistributedMemoryCache
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyAppSession";
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.IsEssential = true;
}); // adding session services

var app = builder.Build();

app.UseSession(); // adding middleware to work with sessions

//app.Run(async context =>
//{
//    if (context.Session.Keys.Contains("name"))
//        await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}");
//    else
//    {
//        context.Session.SetString("name", "Tom");
//        await context.Response.WriteAsync("Hello World!");
//    }
//});

app.Run(async context =>
{
    if (context.Session.Keys.Contains("person"))
    {
        Person? person = context.Session.Get<Person>("person");
        await context.Response.WriteAsync($"Hello {person?.Name}, your age: {person?.Age}!");
    }
    else
    {
        Person person = new Person { Name = "Tom", Age = 37 };
        context.Session.Set<Person>("person", person);
        await context.Response.WriteAsync("Hello World!");
    }
});



app.Run();
