using System.Linq;
using System.Web.Mvc;
using Welic.WebSite.Areas.Admin.Models;
using Registrators;
using Registrators.Plugins;
using Welic.Dominio.Core.Web;
using Welic.Dominio.Enumerables;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PluginController : Controller
    {
        #region Fields
        private readonly ISettingService _settingService;
        private readonly ISettingDictionaryService _settingDictionaryService;

        private readonly ICategoryService _categoryService;
        private readonly IListingService _listingService;

        private readonly DataCacheService _dataCacheService;

        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        private readonly IPluginFinder _pluginFinder;
        #endregion

        #region Constructor
        public PluginController(
            IUnitOfWorkAsync unitOfWorkAsync,
            ISettingService settingService,
            ISettingDictionaryService settingDictionaryService,
            ICategoryService categoryService,
            IListingService listingService,
            DataCacheService dataCacheService,
            IPluginFinder pluginFinder)
        {
            _settingService = settingService;
            _settingDictionaryService = settingDictionaryService;

            _categoryService = categoryService;
            _listingService = listingService;

            _unitOfWorkAsync = unitOfWorkAsync;
            _dataCacheService = dataCacheService;

            _pluginFinder = pluginFinder;
        }
        #endregion

        #region Methods
        public ActionResult Plugins()
        {
            var plugins = _pluginFinder.GetPluginDescriptors(LoadPluginsMode.All).OrderBy(x => x.DisplayOrder).AsQueryable();

            var grid = new PluginsGrid(plugins);

            return View(grid);
        }
        
        public ActionResult Configure(string systemName)
        {
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName(systemName);
            
            string actionUrl = string.Empty;

            if (typeof(IHookPlugin).IsAssignableFrom(pluginDescriptor.PluginType))
            {
                actionUrl = Url.Action("ConfigureHook", "Hook", new { systemName = pluginDescriptor.SystemName });
            }

            // check if there is actionUrl
            if (string.IsNullOrEmpty(actionUrl))
                return HttpNotFound();

            return Redirect(actionUrl);
        }

        public ActionResult Installer(string systemName, int pluginAction)
        {
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName(systemName, LoadPluginsMode.All);

            switch ((Enum_PluginAction)pluginAction)
            {
                case Enum_PluginAction.Install:
                    pluginDescriptor.Instance().Install();
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is installed]]]", systemName);
                    break;
                case Enum_PluginAction.Uninstall:                    
                    pluginDescriptor.Instance().Uninstall();
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is uninstalled]]]", systemName);
                    break;
                case Enum_PluginAction.Enabled:
                    pluginDescriptor.Instance().Enable(true);
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is enabled]]]", systemName);
                    break;
                case Enum_PluginAction.Disabled:
                    pluginDescriptor.Instance().Enable(false);
                    TempData[TempDataKeys.UserMessage] = string.Format("[[[{0} is disabled]]]", systemName);
                    break;
                default:
                    break;
            }                                    
            
            return RedirectToAction("Plugins");
        }


        #endregion
    }
}