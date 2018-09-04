using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Welic.WebSite.Helpers;

namespace Welic.WebSite.Controllers
{
    public class BaseController : Controller
    {
        private static Lazy<AccountController> _lazy = new Lazy<AccountController>(() => new AccountController());
        public static AccountController Current { get { return _lazy.Value; } }
       

        public readonly HttpClient _HttpClient;

        public BaseController()
        {
            _HttpClient = new HttpClient
            {
                //BaseAddress = new Uri("http://localhost:16954/")
                BaseAddress = new Uri("http://192.168.0.14:3000/")
            };
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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