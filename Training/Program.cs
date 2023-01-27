var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Handling HTTP Errors
/*The UseStatusCodePages() method should be called closer to the beginning of the request 
 * processing pipeline, in particular, before adding middleware for working with static files 
 * and before adding endpoints.*/
app.UseStatusCodePages();

app.Map("/hello", () => "Hello ASP.NET Core");

app.Run();
