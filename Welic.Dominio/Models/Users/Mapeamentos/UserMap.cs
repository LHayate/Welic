using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class UserMap
    {
        public string Email { get; set; }
        public string Password { get; set; }        
        public bool RememberMe { get; set; } 
    }
}
