using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Users.Enums;

namespace Welic.Dominio.Models.Users.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
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

        public UserDto( int id, Guid guid, string email)
        {
            Id = id;
            IdGuid = guid;
            Email = email;
        }

        public UserDto()
        {            
        }

        public GroupUserDto GroupUser { get; set; }

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
