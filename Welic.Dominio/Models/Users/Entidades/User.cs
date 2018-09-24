using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Entidades
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string NomeImage { get; set; }
        public DateTime UltimoAcesso { get; set; }


    }
}
