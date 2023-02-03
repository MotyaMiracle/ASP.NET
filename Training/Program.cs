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


app.MapGet("/login", async (HttpContext context) =>
{

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, "Tom"),
        new Claim("languages", "English"),
        new Claim("languages", "German"),
        new Claim("languages", "Spanish")
    };
    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
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
    // similar var username = context.User.Identity.Name
    var username = context.User.FindFirst(ClaimTypes.Name);
    var languages = context.User.FindAll("languages");
    // concatenate the claims list into a string
    var languagesToString = "";
    foreach(var l in languages)
        languagesToString = $"{languagesToString} {l.Value}";
    return $"Name: {username?.Value}\nLanguages: {languagesToString}";
});

app.Run();
