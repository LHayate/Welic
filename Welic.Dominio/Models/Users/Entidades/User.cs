using System;
using System.Collections.Generic;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Scope;
using Welic.Dominio.Utilitarios.Entidades;

namespace Welic.Dominio.Models.Users.Entidades
{
    public class User 
    {
        public string Id { get; set; }
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
        public DateTime LastAccessDate { get; set; }
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
               

        public bool ValidarNomeUsuarioESenha(string nomeUsuario, string password)
        {
            return this.ValidarEscopoNomeUsuarioESenha(nomeUsuario, password);
        }

        public GroupUser GroupUser { get; set; }

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
