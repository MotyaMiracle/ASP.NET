using Microsoft.Extensions.Options;
using Training;

var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("person.json");
builder.Services.Configure<Person>(builder.Configuration);
builder.Services.Configure<Company>(builder.Configuration.GetSection("company"));

var app = builder.Build();

app.Map("/", (IOptions<Company> options) => options.Value);

app.Run();
