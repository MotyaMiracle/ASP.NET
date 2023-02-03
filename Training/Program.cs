using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Training;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// условная бд с пользователями
var people = new List<Person>
{
    new Person{Email = "tom@gmail.com", Password ="12345" },
    new Person{Email = "bob@gmail.com", Password = "55555"}
};

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", async (HttpContext context) =>
{
    var claimsIdentity = new ClaimsIdentity("Undefined");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
    // set authentication cookies
    await context.SignInAsync(claimsPrincipal);
    return Results.Redirect("/");
});

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Данные удалены";
});

app.Map("/", (HttpContext context) =>
{
    var user = context.User.Identity;
    if(user is not null && user.IsAuthenticated)
        return $"Пользователь аутентифицирован. Тип аутентификации: {user.AuthenticationType}";
    else
        return "Пользователь НЕ аутентифицирован";
});

app.Map("/", (ClaimsPrincipal claimsPrincipal) =>
{
    var user = claimsPrincipal.Identity;
    if (user is not null && user.IsAuthenticated)
        return "Пользователь аутентифицирован";
    else return "Пользователь не аутентифицирован";
});

app.Run();
