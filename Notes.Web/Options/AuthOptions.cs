using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Notes.Web.Options
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "MyAuthClient"; 
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 1 * 60 * 24 * 30;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}