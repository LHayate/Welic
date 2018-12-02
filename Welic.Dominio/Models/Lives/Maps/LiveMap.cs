using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Lives.Maps
{
    public class LiveMap : Entity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public string Themes { get; set; }
        public bool Chat { get; set; }
        public string Print { get; set; }
        public string UrlDestino { get; set; }
        public DateTime DateRegister { get; set; }

        public int CourseId { get; set; }
        public ICollection<CursoMap> Courses { get; set; }

        public string TeacherId { get; set; }
        public AspNetUser TeacherUser { get; set; }

        public ICollection<AspNetUser> ClassUser { get; set; }


        public virtual ScheduleMap Schedules { get; set; }
    }
}
