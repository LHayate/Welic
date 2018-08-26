using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste.Models
{
    public class MailModel
    {
        [Required(ErrorMessage ="Obrigatório o Primeiro Nome")]
        [Display(Name ="Primeiro nome!")]        
        public string Nome { get; set; }
        
        [Display(Name = "Ultimo nome!")]
        public string LastName { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "Obrigatório o e-mail")]
        [Display(Name = "E-mail!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}