using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Curso.Map
{
    public class CursoMap : Entity
    {
        public int IdCurso { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public decimal Prince { get; set; }
        public string Themes { get; set; }        
        public byte[] Print { get; set; }

        public string AuthorId { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}
