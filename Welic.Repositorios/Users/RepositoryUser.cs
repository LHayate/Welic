using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Infra.Context;
using Exception = System.Exception;

namespace Welic.Repositorios.Users
{
    public class RepositoryUser : IRepositorioUser
    {
        private readonly AuthContext _contexto;

        public RepositoryUser(AuthContext context)
        {
            _contexto = context;
        }

        public void Save(AspNetUser userMap)
        {                                   
            if(userMap.ObjectState == ObjectState.Modified)            
                _contexto.Entry(userMap).State = EntityState.Modified;
            else                
                _contexto.User.Add(userMap);    
            
            try
            {
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public AspNetUser GetById(string id)
        {
            return _contexto.User.FirstOrDefault(x => x.Id == id.ToString());
        }



        public List<AspNetUser> GetAll()
        {
            return _contexto.User.OrderBy(c => c.Id).ToList();
        }

        public void Delete(string id)
        {
            var userMap = GetById(id);

            if(userMap != null)
                _contexto.User.Remove(userMap);
        }

        public AspNetUser GetByEmail(string email)
        {
            return _contexto.User.FirstOrDefault(x => x.Email == email);
        }

        public AspNetUser GetByName(string name)
        {
            return _contexto.User.FirstOrDefault(x => x.FullName.Contains(name));
        }

        public List<GroupUserMap> GetGroupUser()
        {
            return null; //_contexto.GroupUser.OrderBy(x=> x.Nivel).ToList();
        }
    }
}
