using System.Web.Mvc;

namespace Welic.WebSite.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Install",
                url: "install",
                defaults: new { controller = "Install", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Welic.WebSite.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin",
                "Admin",
                new { action = "Index", controller = "Manage" },
                namespaces: new[] { "Welic.WebSite.Areas.Admin.Controllers" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Welic.WebSite.Areas.Admin.Controllers" }
            );
        }
    }
}