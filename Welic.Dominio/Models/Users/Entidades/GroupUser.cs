using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Entidades;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Users.Entidades
{
    public class GroupUser
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Nivel { get; set; }

        public GroupUser(GroupUserEnum Genum)
        {
            Description = Genum.ToString();
            Nivel = (int)Genum;
        }
        protected GroupUser() { } //For EF

        public static implicit operator GroupUser(GroupUserEnum genum) => new GroupUser(genum);

        public static implicit operator GroupUserEnum(GroupUser groupUser) => (GroupUserEnum)groupUser.Nivel;
    }
}
