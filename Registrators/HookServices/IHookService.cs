using System.Collections.Generic;
using Registrators.Plugins;

namespace Registrators.HookServices
{
    /// <summary>
    /// Hook service interface
    /// </summary>
    public interface IHookService
    {
        /// <summary>
        /// Load active hooks
        /// </summary>
        /// <param name="hookName">Hook name</param>        
        /// <returns>HookPlugins</returns>
        IList<IHookPlugin> LoadActiveHooksByName(string hookName);

        /// <summary>
        /// Load hook by system name
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Found Hook</returns>
        IHookPlugin LoadHookBySystemName(string systemName);
    }
}
