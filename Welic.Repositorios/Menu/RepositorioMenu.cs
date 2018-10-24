using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Menu.Repositorios;
using Welic.Infra.Context;

namespace Welic.Repositorios.Menu
{
    public class RepositorioMenu : IRepositorioMenu
    {
        private AuthContext _context;
        public RepositorioMenu(AuthContext context)
        {
            _context = context;
        }
        public List<MenuMap> ConsultarMenu()
        {
            return _context.Menus.OrderBy(x => x.Id).ToList();
        }        

        public List<MenuMap> GetAllMenu()
        {
            throw new System.NotImplementedException();
        }

        public void SaveMenuUser(int idUser, List<MenuMap> NewMenuUser)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    string queryDelete = "DELETE FROM MenusUser WHERE IdUser = @IdUsuario";
                    _context.Database.ExecuteSqlCommand(queryDelete, new SqlParameter("IdUser", idUser));

                    foreach (MenuMap menu in NewMenuUser)
                    {
                        string query = "INSERT INTO MenusUser (IdUser, IdMenu) VALUES (@IdUser, @IdMenu)";
                        _context.Database.ExecuteSqlCommand(query, new SqlParameter("IdUser", idUser),
                            new SqlParameter("IdMenu", menu.Id));
                    }
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }           
        }

        public List<MenuMap> GetbyIdUser(int idUser)
        {
            string query = Query.Q001;            
            return _context.Database.SqlQuery<MenuMap>(query, new SqlParameter("IdUser", idUser)).ToList();
        }

        public List<MenuMap> GetListbyIdByList(List<int> listaDeIds)
        {
            return _context.Menus.Where(m => listaDeIds.Contains(m.Id)).ToList();
        }
    }
}
