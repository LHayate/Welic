using System.ComponentModel.DataAnnotations;

namespace Welic.WebSite.Models
{
    public class ContactModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
