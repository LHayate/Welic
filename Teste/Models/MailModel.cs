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
        [Display(Name ="Digite seu primeiro nome aqui!")]        
        public string Nome { get; set; }
        
        [Display(Name = "Digite seu ultimo nome aqui!")]
        public string LastName { get; set; }
        public string Subject { get; set; }

        [Required(ErrorMessage = "Obrigatório o e-mail")]
        [Display(Name = "Digite seu e=mail aqui!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}