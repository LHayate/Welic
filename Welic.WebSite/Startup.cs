using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Registrators;
using Unity;
using Unity.AspNet.Mvc;
using Welic.Dominio.Eventos;
using Welic.Dominio.Models.User.Servicos;
using Welic.Infra.Context;
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
            
            ConfigureOAuth(app, container.Resolve<IServiceUser>());
            ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);            
            app.UseWebApi(config);
        }
        public void ConfigureOAuth(IAppBuilder app, IServiceUser servico)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(5),
                Provider = new SimpleAuthorizationServerProvider(servico)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());            

        }
        public static void ConfigureDependencyInjection(HttpConfiguration config, UnityContainer container)
        {
            Registrator.Register(container);
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            
            config.DependencyResolver = new UnityResolverHelper(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            EventoDominio.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}
