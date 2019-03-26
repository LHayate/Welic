using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ContactModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
