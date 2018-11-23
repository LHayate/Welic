using System.Web.Mvc;

namespace Welic.WebSite.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("Error");
            }

            return View("Error");
        }

        public ActionResult Error(System.Web.Mvc.HandleErrorInfo errorInfo)
        {            
            if (Request.IsAjaxRequest())
            {
                return PartialView(errorInfo);
            }

            return View(errorInfo);
        }

        public ActionResult NotFound()
        {
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView();
            //}

            Response.StatusCode = 404;  //you may want to set this to 200
            Response.TrySkipIisCustomErrors = true;

            return View("Error");
        }
    }
}