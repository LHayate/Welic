using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }     
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
