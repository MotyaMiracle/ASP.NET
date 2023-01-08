var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseWelcomePage(); // подключение WelcomePageMiddleware
//app.Run(HandleRequest);
int x = 2;
app.Run(async (context) =>
{
    x = x * 2; // 2 * 2 = 4
    await context.Response.WriteAsync($"Result: {x}");
});
app.Run();

//async Task HandleRequest(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello METANIT.COM 2");
//}
// приложение запущено
//app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));// в этой строке уже нет смысла