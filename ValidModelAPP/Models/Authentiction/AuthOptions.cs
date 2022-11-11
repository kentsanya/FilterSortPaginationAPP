using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ValidModelAPP.Models.Authentiction
{
    public class AuthOptions
    {

        public const string ISSUER = "MyAuthServer";
        public const string AUIDENCE = "MyAuthClient";
        const string KEY = "my_key_acess_supersecret!246";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() 
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }

    }
}
