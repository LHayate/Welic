using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseFul.ClientApi.Dtos
{
    public enum TypeProgram
    {
        Cadastro = 1,
        processo = 2,

        relatorio = 3,
    }
    public class ProgramDto
    {
        public int IdProgram { get; set; }
        public string Description { get; set; }
        public TypeProgram Type { get; set; }
        public bool Active { get; set; }        
    }
}
