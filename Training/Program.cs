var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("/hello", () => SendHello);
//app.Map("/", () => "Hello ASP.NET Core");

app.Run(async context =>
{
    await Results.Text("Hello ASP.NET Core").ExecuteAsync(context);
});

app.Run();

IResult SendHello()
{
    return Results.Text("Hello ASP.NET Core");
}
