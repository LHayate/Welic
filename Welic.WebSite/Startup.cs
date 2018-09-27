using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Welic.Dominio.Eventos;
using Welic.Registrators;
using Welic.WebSite.Helpers;
using Welic.WebSite.Provider;

[assembly: OwinStartup(typeof(Welic.WebSite.Startup))]
namespace Welic.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)  
        {
                                          

            HttpConfiguration config = new HttpConfiguration();
            UnityContainer container = new UnityContainer();
            

            ConfigureDependencyInjection(config, container);
            ConfigureOAuth(app);
            ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);            
            app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());            

        }
        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            Registrator.Register(container);
            config.DependencyResolver = new UnityResolverHelper(container);
            //EventoDominio.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}
