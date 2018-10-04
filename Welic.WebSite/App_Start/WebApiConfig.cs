using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;

namespace Welic.WebSite
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            MediaTypeFormatterCollection formatters = config.Formatters;
            //Habilitar xml
            formatters.Remove(formatters.XmlFormatter);

            JsonSerializerSettings jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            // Web API routes
            config.MapHttpAttributeRoutes();            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultCategory",
                routeTemplate: "api/{controller}/{category}/{id}",
                defaults: new { category = "all", id = RouteParameter.Optional }
            );

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "ConventionalDefault",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
