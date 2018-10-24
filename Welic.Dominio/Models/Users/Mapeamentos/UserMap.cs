using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Menu.Mapeamentos;
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
        public string NickName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string Identity { get; set; }
        public DateTime LastAcess { get; set; }

        public ICollection<ScheduleMap> SchedulesTeacher { get; set; }

        public ICollection<ScheduleMap> SchedulesClass { get; set; }

        public ICollection<LiveMap> Lives { get; set; }
        
        public GroupUserMap GroupUserMap { get; set; }
        private ICollection<MenuMap> _menus;

        public ICollection<MenuMap> Menus
        {
            get => _menus;

            private set => _menus = new List<MenuMap>(value);
        }

    }
}
