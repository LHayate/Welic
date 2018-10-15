using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.Dominio.Models.Schedule.Dtos
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Prince { get; set; }
        public DateTime DateEvent { get; set; }
        public bool Private { get; set; }
        public bool Ativo { get; set; }
        public UserDto UserTeacher { get; set; }
        public ICollection<UserDto> UserClass { get; set; }
        public LiveDto Live { get; set; }


        public ScheduleDto()
        {
            UserTeacher = new UserDto();
            UserClass = new List<UserDto>();
            Live = new LiveDto();
        }
    }
}
