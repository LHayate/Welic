using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.WebSite.Helpers;

namespace Welic.WebSite.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServicoMenu _servicoMenu;
        private readonly IServiceUser _serviceUser;
        public BaseController(IServicoMenu servicoMenu, IServiceUser serviceUser)
        {
            _servicoMenu = servicoMenu;
            _serviceUser = serviceUser;
        }

        public BaseController()
        {
            
        }
        
        public ActionResult Menu(string email)
        {            
            var list = _servicoMenu.GetMenuByUser(email);
            return PartialView(list);

        }

        public PartialViewResult NavBar()
        {
            return PartialView();
        }
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            // Attempt to read the culture cookie from Request
            if (!(RouteData.Values["culture"] is string cultureName))
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            if (RouteData.Values["culture"] as string != cultureName)
            {

                // Force a valid culture in the URL
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too

                // Redirect user
                Response.RedirectToRoute(RouteData.Values);
            }

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            return base.BeginExecuteCore(callback, state);
        }

    }
}