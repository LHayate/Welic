using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Enums;

namespace Welic.WebSite.Models
{
    public class GroupUserDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Nivel { get; set; }

        public List<GroupUser> ListaGroupUser()
        {
            return new List<GroupUser>
            {
                new GroupUser(GroupUserEnum.None),
                new GroupUser(GroupUserEnum.Teacher),
                new GroupUser(GroupUserEnum.Student),
                new GroupUser(GroupUserEnum.TeacherStudent),
            };
        }
    }
}