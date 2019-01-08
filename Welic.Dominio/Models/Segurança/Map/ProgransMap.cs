using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Segurança.Map
{
    public enum TypeProgram
    {
        Cadastro = 1,
        processo = 2,
        relatorio = 3,
    }

    public class ProgransMap : Entity
    {
        public int IdProgram { get; set; }
        public string Description { get; set; }
        public TypeProgram Type { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<PermissionMap> Permission { get; set; }
    }
}
