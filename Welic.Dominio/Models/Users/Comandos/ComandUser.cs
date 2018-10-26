using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Comandos
{
    public class ComandUser
    {
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Senha { get; set; }

        public ComandUser()
        {
            
        }

        public ComandUser(string nickName, string senha, string email)
        {
            NickName = nickName;
            Senha = senha;
            Email = email;
        }
    }
}
