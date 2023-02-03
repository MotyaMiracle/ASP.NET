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
    new Person("tom@gmail.com", "12345", "London", "Microsoft"),
    new Person("bob@gmail.com", "55555", "Лондон", "Google"),
    new Person("sam@gmail.com", "11111", "Berlin", "Microsoft")
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/accessdenied";
    });
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("OnlyForLondon", policy =>
    {
        policy.RequireClaim(ClaimTypes.Locality, "Лондон", "London");
    });
    opts.AddPolicy("OnlyForMicrosoft", policy =>
    {
        policy.RequireClaim("company", "Microsoft");
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
        new Claim(ClaimTypes.Locality, person.City),
        new Claim("company", person.Company)
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect(returnUrl ?? "/");
});

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
    var city = context.User.FindFirst(ClaimTypes.Locality);
    var company = context.User.FindFirst("company");
    return $"Name: {login?.Value}\nCity: {city?.Value}\nCompany: {company?.Value}";
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Данные удалены";
});

app.Run();
