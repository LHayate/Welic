using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class ProgramGroupUserMap: Entity
    {
        public ProgramsMap IdProgram { get; set; }
        public GroupUserMap IdGroup { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

    }
}
