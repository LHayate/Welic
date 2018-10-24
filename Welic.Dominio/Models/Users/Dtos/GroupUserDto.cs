using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Enums;

namespace Welic.Dominio.Models.Users.Dtos
{
    public class GroupUserDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Nivel { get; set; }

        public GroupUserDto(GroupUserEnum Genum)
        {
            Description = Genum.ToString();
            Nivel = (int)Genum;
        }

        public GroupUserDto()
        {
            
        }

        public static implicit operator GroupUserDto(GroupUserEnum genum) => new GroupUserDto(genum);

        public static implicit operator GroupUserEnum(GroupUserDto groupUser) => (GroupUserEnum)groupUser.Nivel;

        public List<GroupUserDto> ListaGroupUser()
        {
            return new List<GroupUserDto>
            {
                new GroupUserDto(GroupUserEnum.None),
                new GroupUserDto(GroupUserEnum.Teacher),
                new GroupUserDto(GroupUserEnum.Student),
                new GroupUserDto(GroupUserEnum.TeacherStudent),
            };
        }
    }
}
