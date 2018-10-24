using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Enums;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public class GroupUserMap
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Nivel { get; set; }

        public ICollection<UserMap> Users { get; set; }

        public GroupUserMap(GroupUserEnum Genum)
        {            
            Description = Genum.ToString();
            Nivel = (int) Genum;
        }
        protected GroupUserMap() { } //For EF

        public static implicit operator GroupUserMap(GroupUserEnum genum) => new GroupUserMap(genum);

        public static implicit operator GroupUserEnum(GroupUserMap groupUser) => (GroupUserEnum)groupUser.Nivel;
    }
}
