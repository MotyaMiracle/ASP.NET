var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Handling HTTP Errors
/*The UseStatusCodePages() method should be called closer to the beginning of the request 
 * processing pipeline, in particular, before adding middleware for working with static files 
 * and before adding endpoints.*/
//app.UseStatusCodePages("text/plain", "Error: Resource Not Found. Status code: {0}");

//app.UseStatusCodePages(async statusCodeContext =>
//{
//    var response = statusCodeContext.HttpContext.Response;
//    var path = statusCodeContext.HttpContext.Request.Path;

//    response.ContentType = "text/plain; charset=UTF-8";
//    if (response.StatusCode == 403)
//    {
//        await response.WriteAsync($"Path: {path}. Access denied");
//    }
//    else if (response.StatusCode == 404)
//    {
//        await response.WriteAsync($"Path: {path}. Not found");
//    }
//});

//app.UseStatusCodePagesWithRedirects("/error/{0}");
//app.UseStatusCodePagesWithReExecute("/error/{0}");
//Second parameter accepts query string parameters
app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

app.Map("/hello", () => "Hello ASP.NET Core");
app.Map("/error", (string code) => $"Error Code: {code}");
//app.Map("/error/{statusCode}", (int statusCode) => $"Error. Status Code: {statusCode}");

app.Run();
