using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Schedule.Maps;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class UserMap
    {
        [Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string NomeCompleto { get; set; }        
        public byte[] ImagemPerfil { get; set; }
        public string NomeImage { get; set; }
        public DateTime UltimoAcesso { get; set; }


        public ICollection<ScheduleMap> SchedulesTeacher { get; set; }

        public ICollection<ScheduleMap> SchedulesClass { get; set; }

        public ICollection<LiveMap> Lives { get; set; }
    }
}
