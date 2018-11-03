using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Welic.WebSite.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DoAction(this HtmlHelper helper, string hookName, object additionalData = null)
        {
            return helper.Action("DoAction", "Hook", new { hookName = hookName, additionalData = additionalData, area = "" });
        }
    }
}