using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Training
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // token publisher
        public const string AUDIENCE = "MyAuthClient"; // token consumer
        const string KEY = "mysupersecret_secretkey!123"; // encryption key
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
