using System;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Infra.Context;
using Welic.Repositorios.Login;
using Welic.WebSite.Models;


namespace Welic.WebSite.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IServiceUser _servico;
        #region Fields
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        #endregion

        private ApplicationDbContext _ctx;
        
        #region Properties
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion

        public SimpleAuthorizationServerProvider(IServiceUser servico)
        {
            _servico = servico;                        
        }        

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) => context.Validated();

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            ComandUser usuarioComando = new ComandUser(context.UserName.ToLower(), context.Password, context.UserName);
            User user = _servico.Autenticar(usuarioComando);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }


            //using (AuthRepository _repo = new AuthRepository())
            //{
            //    IdentityUser user1 = await _repo.FindUser(context.UserName, context.Password);
            //    var user = await Login(context.UserName, context.Password);

            //    if (user == null)
            //    {
            //        context.SetError("invalid_grant", "The user name or password is incorrect.");
            //        return;
            //    }
            //}

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }

        public async Task<IdentityUser> Login(string userName, string password)
        {
            
            var user = await UserManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                throw new Exception("User Not Find.");
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return user;                                   
                case SignInStatus.Failure:
                default:                    
                    return null;
            }
        }             
    }
}