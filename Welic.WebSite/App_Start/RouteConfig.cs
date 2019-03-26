using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
            name: "DefaultLocalized",
            url: "{culture}/{controller}/{action}/{id}",
            defaults: new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
                culture = "pt-BR"
            },
            constraints: new { culture = "[a-z]{2}-[A-Z]{2}" },
            namespaces: new[] { "WebApi.Controllers" }
            );
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Page",
                url: "page/{id}",
                defaults: new { controller = "Home", action = "ContentPage", id = UrlParameter.Optional, culture = "pt-BR" },
                namespaces: new[] { "WebApi.Controllers" }

            );

            routes.MapRoute(
                name: "Listings",
                url: "listings/{id}",
                defaults: new { controller = "Listing", action = "Listing", id = UrlParameter.Optional, culture = "pt-BR" },
                namespaces: new[] { "WebApi.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, culture = "pt-BR" },
                namespaces: new[] { "WebApi.Controllers" }
            );

            //routes.MapHttpRoute(
            //    name: "ActionApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
