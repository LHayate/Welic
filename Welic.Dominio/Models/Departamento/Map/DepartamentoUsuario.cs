using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Departamento.Map
{
    public class DepartamentoUsuario : Entity
    {
       
        [Key, Column(Order = 1)]
        public int IdDepartamento { get; set; }
        [Key, Column(Order = 2)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AspNetUser AspNetUser { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual DepartamentoMap Departamentos { get; set; }




    }
}
