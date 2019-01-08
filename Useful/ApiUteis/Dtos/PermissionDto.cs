using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public class PermissionDto
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
    }
}
