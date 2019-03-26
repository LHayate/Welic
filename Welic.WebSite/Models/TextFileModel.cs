using System.Web.Mvc;

namespace WebApi.Models
{
    public class TextFileModel
    {
        [AllowHtml]
        public string Text { get; set; }
    }
}