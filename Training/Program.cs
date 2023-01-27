var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.UseDeveloperExceptionPage();
app.Environment.EnvironmentName = "Production"; // change Enviroment

// if the application is not under development
// redirect to "/error"
if (!app.Environment.IsDevelopment())
{
    //Note that app.UseExceptionHandler() should be placed closer
    //to the beginning of the middleware pipeline.
    app.UseExceptionHandler(app => app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync($"Error 500. DivideByZeroException occurred!");
    }));
}
//However, this method has a small drawback -
// we can directly access "/error" and get the same response from the server.
// middleware that handles the exception
//app.Map("/error", app => app.Run(async context =>
//{
//    context.Response.StatusCode = 500;
//    await context.Response.WriteAsync($"Error 500. DivideByZeroException occurred!");
//}));
// middleware where the exception is thrown
app.Run(async context =>
{
    int a = 5;
    int b = 0;
    int c = a / b;
    await context.Response.WriteAsync($"c = {c}");
});

app.Run();
