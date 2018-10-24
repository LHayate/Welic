using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Welic.WebSite.Controllers
{    
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Dashboard
        public ActionResult Admin()
        {
            return View();
        }        
    }
}
