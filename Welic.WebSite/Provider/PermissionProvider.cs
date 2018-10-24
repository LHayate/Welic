using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Welic.Dominio.Models.User.Servicos;

namespace Welic.WebSite.Provider
{
    public class PermissionProvider :  RoleProvider
    {
        private readonly IServiceUser _servico;

        public PermissionProvider(IServiceUser servico)
        {
            _servico = servico;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //TODO: IMplementar consulta de Permissões http://devbrasil.net/profiles/blogs/autentica-o-e-permiss-es-de-usu-rios-em-asp-net-mvc-4
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}