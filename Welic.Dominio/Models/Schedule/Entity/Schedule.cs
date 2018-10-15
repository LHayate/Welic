using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Lives.Entitys;


namespace Welic.Dominio.Models.Schedule.Entity
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }
        public Users.Entidades.User UserTeacher { get; set; }
        public ICollection<Users.Entidades.User> UserClass { get; set; }
        public Live Live { get; set; }

    }
}
