using Microsoft.Extensions.Options;
using Training;

var builder = WebApplication.CreateBuilder();
builder.Configuration.AddJsonFile("person.json");
builder.Services.Configure<Person>(builder.Configuration);
builder.Services.Configure<Person>(opt =>
{
    opt.Age = 22;
});

var app = builder.Build();

app.Map("/", (IOptions<Person> options) =>
{
    Person person = options.Value;  // получаем переданные через Options объект Person
    return person;
});

app.Run();
