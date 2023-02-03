using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Training;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var adminRole = new Role("admin");
var userRole = new Role("user");
var people = new List<Person>
{
    new Person("tom@gmail.com", "12345", 1984),
    new Person("bob@gmail.com", "55555", 2006)
};

var builder = WebApplication.CreateBuilder(args);
// embed the AgeHandler service
builder.Services.AddTransient<IAuthorizationHandler, AgeHandler>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessdenied";
    });
builder.Services.AddAuthorization(opts =>
{
    // set age limit
    opts.AddPolicy("AgeLimit", policy =>
    {
        policy.AddRequirements(new AgeRequirement(18));
    });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/accessdenied", async (HttpContext context) =>
{
    context.Response.StatusCode = 403;
    await context.Response.WriteAsync("Access Denied");
});

app.MapGet("/login", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    string loginForm = @"<!DOCTYPE html>
    <html>
    <head>
        <meta charset='utf-8' />
        <title>METANIT.COM</title>
    </head>
    <body>
        <h2>Login Form</h2>
        <form method='post'>
            <p>
                <label>Email</label><br />
                <input name='email' />
            </p>
            <p>
                <label>Password</label><br />
                <input type='password' name='password' />
            </p>
            <input type='submit' value='Login' />
        </form>
    </body>
    </html>";
    await context.Response.WriteAsync(loginForm);
});

app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
{
    // get email and password from the form
    var form = context.Request.Form;
    // if email and/or password are not set, send a 400 error status code
    if (!form.ContainsKey("email") || !form.ContainsKey("password"))
        return Results.BadRequest("Email и/или пароль не установлены");
    string email = form["email"];
    string password = form["password"];
    // find the user
    Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
    // if user not found, send status code 401
    if (person is null) return Results.Unauthorized();
    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, email),
        new Claim(ClaimTypes.DateOfBirth, person.Year.ToString())
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});

// access only for those who meet the Age Limit
app.Map("/age", [Authorize(Policy = "AgeLimit")] () => "Age Limit is passed");

// access only for City = London
app.Map("/london", [Authorize(Policy = "OnlyForLondon")] () => "You are living in London");

// access only for Company = Microsoft
app.Map("/microsoft", [Authorize(Policy = "OnlyForMicrosoft")]() => "You are working in Microsoft");

// access only for the admin role
app.Map("/admin", [Authorize(Roles = "admin")] () => "Admin Panel");

// access only for admin and user roles
app.Map("/", /*[Authorize(Roles = "admin, user")]*/ (HttpContext context) =>
{
    var login = context.User.FindFirst(ClaimTypes.Name);
    var year = context.User.FindFirst(ClaimTypes.DateOfBirth);
    return $"Name: {login?.Value}\nYear: {year?.Value}";
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "ƒанные удалены";
});

app.Run();
