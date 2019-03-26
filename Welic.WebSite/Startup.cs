using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Registrators;
using Unity;
using WebApi;
using Welic.Dominio.Eventos;
using Welic.Dominio.Models.Users.Servicos;
using WebApi.Helpers;
using WebApi.Provider;

//[assembly: OwinStartup(typeof(Startup))]
[assembly: OwinStartupAttribute("StartupConfig", typeof(Startup))]
namespace WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            HttpConfiguration config = new HttpConfiguration();
            var container = ContainerManager.GetConfiguredContainer();  

            ConfigureDependencyInjection(config, container);

            ConfigureOAuth(app, ContainerManager.GetConfiguredContainer().Resolve<IServiceUser>());
            ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);            
            app.UseWebApi(config);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
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
        public static void ConfigureDependencyInjection(HttpConfiguration config, IUnityContainer container)
        {            
            config.DependencyResolver = new UnityResolverHelper(container);

            EventoDominio.Container = new DomainEventsContainer(config.DependencyResolver);
        }
    }
}
