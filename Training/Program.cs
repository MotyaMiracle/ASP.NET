var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseDeveloperExceptionPage();
app.Environment.EnvironmentName = "Production"; // change Enviroment

app.Run(async context =>
{
    int a = 5;
    int b = 0;
    int c = a / b;
    await context.Response.WriteAsync($"c = {c}");
});

app.Run();
