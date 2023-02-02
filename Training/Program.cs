using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Training;


// conditional database with users
var people = new List<Person>
{
    new Person{Email = "tom@gmail.com", Password = "12345"},
    new Person{Email = "bob@gmail.com", Password = "55555"}
};

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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication(); // add authentication middleware
app.UseAuthorization(); // adding authorization middleware

app.MapPost("/login", (Person loginData) =>
{
    // find the user
    Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
    // if user not found, send status code 401
    if (person is null)
        return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Email) };
    // create a JWT token
    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), 
        SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    // form the response
    var response = new
    {
        access_token = encodedJwt,
        username = person.Email
    };
    
    return Results.Json(response);
});


app.Map("/data", [Authorize] () => $"Hello World!");


app.Run();
