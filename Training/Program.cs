using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", IndexHandler);
app.Map("/about", async context =>
{
    await context.Response.WriteAsync("About Page");
});
app.Map("/contact", () => "Contacts Page");
app.Map("/user", PersonHandler);
app.Map("/users", () => Console.Write("Request Path: /users"));

app.MapGet("/routes", (IEnumerable<EndpointDataSource> endpointSource) =>
        string.Join("\n", endpointSource.SelectMany(source => source.Endpoints)));

//More detail information
//app.MapGet("/routesDetail", (IEnumerable<EndpointDataSource> endpointSources) =>
//{
//    var sb = new StringBuilder();
//    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
//    foreach (var endpoint in endpoints)
//    {
//        sb.AppendLine(endpoint.DisplayName);

//        // получим конечную точку как RouteEndpoint
//        if (endpoint is RouteEndpoint routeEndpoint)
//        {
//            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
//        }

//        // получение метаданных
//        // данные маршрутизации
//        // var routeNameMetadata = endpoint.Metadata.OfType<Microsoft.AspNetCore.Routing.RouteNameMetadata>().FirstOrDefault();
//        // var routeName = routeNameMetadata?.RouteName;
//        // данные http - поддерживаемые типы запросов
//        //var httpMethodsMetadata = endpoint.Metadata.OfType<HttpMethodMetadata>().FirstOrDefault();
//        //var httpMethods = httpMethodsMetadata?.HttpMethods; // [GET, POST, ...]
//    }
//    return sb.ToString();
//});

app.Run();

string IndexHandler()
{
    return "Index Page";
}

Person PersonHandler()
{
    return new Person("Tom", 37);
}
record class Person(string Name, int Age);
