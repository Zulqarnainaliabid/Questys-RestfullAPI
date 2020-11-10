using Microsoft.AspNetCore.Authentication;

namespace Questys.RestfullAPI.Repository.Api
{
    public class AuthenticateOptions : AuthenticationSchemeOptions
    {
        public const string Authorization = "authorization";
    }
}
