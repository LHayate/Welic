using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Welic.Core;

namespace Registrators.Plugins
{
    public abstract class HookBasePlugin : BasePlugin, IHookPlugin
    {
        public Dictionary<string, RouteValueDictionary> HookRoutes { get; set; }

        public HookBasePlugin()
        {
            HookRoutes = new Dictionary<string, RouteValueDictionary>();
        }

        public void AddRoute(string hookName, RouteValueDictionary routeValueDictionary)
        {
            HookRoutes.Add(hookName, routeValueDictionary);
        }

        public RouteValueDictionary GetRoute(string hookName)
        {            
            if (!HookRoutes.ContainsKey(hookName))
                return null;

            return HookRoutes[hookName];
        }

        public IList<string> GetHookNames()
        {
            return HookRoutes.Keys.ToList();
        }

        public RouteValueDictionary GetConfigurationRoute()
        {
            return GetRoute(HookName.Configuration);
        }

        public abstract Type GetControllerType();
    }
}
