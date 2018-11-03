using System.Web.Mvc;

namespace Welic.WebSite.Models
{
    public class TextFileModel
    {
        [AllowHtml]
        public string Text { get; set; }
    }
}