using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.News.Maps;

namespace Welic.Dominio.Models.News.Repositoryes
{
    public interface IRepositoryNews
    {
        void Save(NewsMap newsMap);
        NewsMap GetById(int id);
        List<NewsMap> GetList();
        void Delete(int id);
    }
}
