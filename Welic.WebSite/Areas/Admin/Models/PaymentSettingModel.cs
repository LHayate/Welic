using System.Collections.Generic;
using Registrators.Plugins;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Areas.Admin.Models
{
    public class PaymentSettingModel
    {
        public Setting Setting { get; set; }

        public List<PluginDescriptor> PaymentPlugins { get; set; }
    }
}