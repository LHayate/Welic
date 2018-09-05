using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Welic.WebSite.Startup))]
namespace Welic.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
