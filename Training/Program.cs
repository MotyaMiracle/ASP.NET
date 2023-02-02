using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Training;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(); // adding authorization services
// adding authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            // indicates whether the publisher will be validated when the token is validated
            ValidateIssuer = true,
            // string representing the publisher
            ValidIssuer = AuthOptions.ISSUER,
            // whether the consumer of the token will be validated
            ValidateAudience = true,
            // set consumer token
            ValidAudience = AuthOptions.AUDIENCE,
            // whether lifetime will be validated
            ValidateLifetime = true,
            // set the security key
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // validate the security key
            ValidateIssuerSigningKey = true,
        };
    });
var app = builder.Build();

app.UseAuthentication(); // add authentication middleware
app.UseAuthorization(); // adding authorization middleware

app.Map("/login/{username}", (string username) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    // create a JWT token
    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), 
        SecurityAlgorithms.HmacSha256));
    return new JwtSecurityTokenHandler().WriteToken(jwt);
});


app.Map("/data", [Authorize] () => new {message = "Hello World!" });


app.Run();
