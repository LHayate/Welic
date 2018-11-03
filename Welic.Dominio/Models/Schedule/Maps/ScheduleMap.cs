﻿using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Schedule.Maps
{
    public class ScheduleMap : Patterns.Pattern.Ef6.Entity
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }

        public AspNetUser UserTeacher { get; set; }
        public ICollection<AspNetUser> UserClass { get; set; }
        public LiveMap Live { get; set; }
    }
}
