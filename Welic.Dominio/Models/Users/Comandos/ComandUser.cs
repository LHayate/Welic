using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Comandos
{
    public class ComandUser
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public ComandUser()
        {
            
        }

        public ComandUser(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }
    }
}
