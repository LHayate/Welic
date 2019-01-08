using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Departamento.Map
{
    public class DepartamentoMap: Entity
    {
        public int IdDepartamento { get; set; }
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public EmpresaMap EmpresaMap { get; set; }
        public ICollection<AspNetUser> AspNetUsers { get; set; }

    }
}
