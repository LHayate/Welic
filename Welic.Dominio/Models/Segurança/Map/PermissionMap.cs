using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Segurança.Map
{
    public class PermissionMap: Entity
    {
        public int IdPermissao { get; set; }
        public string IdUser { get; set; }
        public int IdProgram { get; set; }
        public bool All { get; set; }
        public bool Read { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Active { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public ProgransMap ProgransMap { get; set; }

    }
}
