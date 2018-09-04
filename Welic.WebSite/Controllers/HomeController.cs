using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welic.WebSite.Helpers;

namespace Welic.WebSite.Controllers
{
    public class HomeController : BaseController 
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            RouteData.Values["culture"] = culture;  // set culture


            return RedirectToAction("Index");

            //// Save culture in a cookie
            //HttpCookie cookie = Request.Cookies["_culture"];
            //if (cookie != null)
            //    cookie.Value = culture;   // update cookie value
            //else
            //{

            //    cookie = new HttpCookie("_culture")
            //    {
            //        Value = culture,
            //        Expires = DateTime.Now.AddYears(1)
            //    };
            //}
            //Response.Cookies.Add(cookie);

            //return RedirectToAction("Index");
        }
    }
}