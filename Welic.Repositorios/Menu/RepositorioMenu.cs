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

        public List<MenuMap> GetAllMenu()
        {
            return _context.Menus.OrderBy(x => x.Id).ToList();
        }       

        public void SaveMenuUser(string idUser, List<MenuMap> NewMenuUser)
        {
            using (DbContextTransaction dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    string queryDelete = "DELETE FROM MenusUser WHERE IdUser = @IdUser";
                    _context.Database.ExecuteSqlCommand(queryDelete, new SqlParameter("IdUser", idUser));

                    foreach (MenuMap menu in NewMenuUser)
                    {
                        string query = "INSERT INTO MenusUser (IdUser, IdMenu) VALUES (@IdUser, @IdMenu)";
                        _context.Database.ExecuteSqlCommand(query, new SqlParameter("IdUser", idUser),
                            new SqlParameter("IdMenu", menu.Id));
                    }
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public List<MenuMap> GetbyIdUser(int idUser)
        { 
            string query = Query.Q001;
                                    
            var result =  _context.Database.SqlQuery<MenuMap>(query, new SqlParameter("IdUser", idUser)).ToList();

            return result;                                       
        }

        public List<MenuMap> GetbyIdUser(string nameUser)
        {
            string query = Query.Q001;
            return _context.Database.SqlQuery<MenuMap>(query, new SqlParameter("IdUser", nameUser)).ToList();
        }

        public List<MenuMap> GetListbyIdByList(List<int> listaDeIds)
        {
            return _context.Menus.Where(m => listaDeIds.Contains(m.Id)).ToList();
        }

        public void Save(MenuMap menuMap)
        {
            var found = GetById(menuMap.Id);

            if (found != null)
                _context.Entry(menuMap).State = EntityState.Modified;
            else
                _context.Menus.Add(menuMap);

            _context.SaveChanges();
        }

        public MenuMap GetById(int id)
        {
            return _context.Menus.FirstOrDefault(x => x.Id == id);
        }
    }
}
