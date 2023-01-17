using Training;

var builder = WebApplication.CreateBuilder(args);

// проецируем класс SecretCodeConstraint на inline-ограничение secretcode
builder.Services.Configure<RouteOptions>(options =>
            options.ConstraintMap.Add("secretcode", typeof(SecretCodeConstraint)));


// альтернативное добавление класса ограничения
// builder.Services.AddRouting(options =>
//              options.ConstraintMap.Add("secretcode", typeof(SecretConstraint)));
builder.Services.AddRouting(options =>
                options.ConstraintMap.Add("invalidnames", typeof(InvalidNamesConstraint)));

var app = builder.Build();

app.Map("/users/{name}/{token:secretcode(123456)}/", (string name, int token) =>
            $"Name: {name} \nToken: {token}");
app.Map("/users/{name:invalidnames}", (string name) => $"Name: {name}");
app.Map("/", () => "Index Page");

app.Run();
