using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Users.Enums;

namespace Welic.Dominio.Models.Users.Dtos
{
    public class UserDto
    {
        public string UserId { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string Identity { get; set; }
        public DateTime LastAcess { get; set; }
        public string LastAccessIP { get; set; }
        public System.DateTime RegisterDate { get; set; }
        public string RegisterIP { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int LeadSourceID { get; set; }
        public bool AcceptEmail { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool Disabled { get; set; }
        public double Rating { get; set; }

        public UserDto( string id, Guid guid, string email)
        {
            UserId = id;
            Guid = guid;
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
