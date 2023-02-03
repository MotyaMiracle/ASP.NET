using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Training;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.UseAuthentication();


app.MapGet("/login/{username}", async (string username,HttpContext context) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    var claimIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimPrincipal = new ClaimsPrincipal(claimIdentity);
    await context.SignInAsync(claimPrincipal);
    return $"Установлено имя {username}";
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
        return $"UserName: {user.Name}";
    else
        return "Пользователь НЕ аутентифицирован";
});

app.Run();
