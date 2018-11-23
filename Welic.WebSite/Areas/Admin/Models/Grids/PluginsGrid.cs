using GridMvc;
using System.Linq;
using Registrators.Plugins;

namespace Welic.WebSite.Areas.Admin.Models
{
    public class PluginsGrid : Grid<PluginDescriptor>
    {
        public PluginsGrid(IQueryable<PluginDescriptor> plugins)
            : base(plugins)
        {
        }
    }
}