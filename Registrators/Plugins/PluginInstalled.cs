using System.Collections.Generic;

namespace Registrators.Plugins
{
    public class PluginInstalled
    {
        public List<PluginState> Plugins { get; set; }
    }

    public class PluginState
    {
        public string SystemName { get; set; }        

        public bool Enabled { get; set; }
    }
}
