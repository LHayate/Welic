using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Curso.Map
{
    public class CursoMap : Entity
    {
        public CursoMap()
        {
            Live = new List<LiveMap>();
        }
        public int IdCurso { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }        
        public decimal Prince { get; set; }
        public string Themes { get; set; }        
        public byte[] Print { get; set; }

        public string AuthorId { get; set; }
        public AspNetUser TeacherUser { get; set; }
        public ICollection<LiveMap> Live { get; set; }

        public virtual ICollection<AspNetUser> UserClass { get; set; }
        public virtual ICollection<EBookMap> Ebook { get; set; }
    }
}
