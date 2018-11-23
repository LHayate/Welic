using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class ProgramsMap : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
