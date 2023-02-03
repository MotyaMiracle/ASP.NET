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

// Add age
app.MapGet("/addage", async (HttpContext context) =>
{
    if (context.User.Identity is ClaimsIdentity claimsIdentity)
    {
        claimsIdentity.AddClaim(new Claim("age", "37"));
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await context.SignInAsync(claimsPrincipal);
    }
    return Results.Redirect("/");
});

// delete phone
app.MapGet("/removephone", async (HttpContext context) =>
{
    if (context.User.Identity is ClaimsIdentity claimsIdentity)
    {
        var phoneClaim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);
        // if the claim is successfully deleted
        if (claimsIdentity.TryRemoveClaim(phoneClaim))
        {
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await context.SignInAsync(claimsPrincipal);
        }
    }
    return Results.Redirect("/");
});

app.MapGet("/login", async (HttpContext context) =>
{
    var username = "Tom";
    var company = "Microsoft";
    var phone = "+12345678901";

    var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, username),
        new Claim("company", company),
        new Claim(ClaimTypes.MobilePhone, phone)
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
    var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
    var company = context.User.FindFirst("company");
    var age = context.User.FindFirst("age");
    return $"Name: {username?.Value}\nPhone: {phone?.Value}\n" +
    $"Company: {company?.Value}\nAge: {age?.Value}";
});

app.Run();
