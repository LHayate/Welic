using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Dtos;
using Welic.WebSite.API.Controllers;


namespace Welic.WebSite.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) => context.Validated();

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (AccountController repo = new AccountController())
            {
                UserDto usuario = new UserDto
                {
                    Email = context.UserName,
                    Password = context.Password,
                    UserName = context.UserName,
                    RememberMe = false
                };

                if (!(await repo.Login(usuario)))
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
            }            

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}