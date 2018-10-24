﻿using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Entidades;


namespace Welic.WebSite.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IServiceUser _servico;

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

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}