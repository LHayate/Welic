using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;
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

        public void Save(UserMap userMap)
        {
            var user = _contexto.User.Find(userMap.Id);
            if (user != null)
                _contexto.Entry(userMap).State = EntityState.Modified;
            else
                //_contexto.Entry(userMap).State = EntityState.Added; //   User.Add(userMap);}
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

        public UserMap GetById(int id)
        {
            return _contexto.User.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var userMap = GetById(id);

            if(userMap != null)
                _contexto.User.Remove(userMap);
        }

        public UserMap GetByEmail(string email)
        {
            return _contexto.User.FirstOrDefault(x => x.Email == email);
        }
    }
}
