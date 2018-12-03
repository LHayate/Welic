using System;
using System.Collections.Generic;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Schedule.Maps
{
    public class ScheduleMap : Patterns.Pattern.Ef6.Entity
    {
        public ScheduleMap()
        {
            //UserClass = new List<AspNetUser>();
        }
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }

        public string TeacherId { get; set; }    
        public AspNetUser UserTeacher { get; set; }

        public virtual ICollection<AspNetUser> UserClass { get; set; }
        
        public virtual LiveMap Live { get; set; }
        public EBookMap Ebook { get; set; }
    }
}
