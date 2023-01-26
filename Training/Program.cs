var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    //context.Items["text"] = "Hello from HttpContext.Items";
    context.Items.Add("message", "Hello METANIT.COM");
    await next.Invoke();
});

app.Run(async context => {

    if (context.Items.ContainsKey("message"))
        await context.Response.WriteAsync($"Message: {context.Items["message"]}");
    else
        await context.Response.WriteAsync("Random Text");
});

app.Run();
