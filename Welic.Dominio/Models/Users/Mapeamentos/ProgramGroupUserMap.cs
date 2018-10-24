using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class ProgramGroupUserMap
    {
        public ProgramsMap IdProgram { get; set; }
        public GroupUserMap IdGroup { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

    }
}
