using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Maps;

namespace Welic.Dominio.Models.Lives.Repositoryes
{
    public interface IRepositoryLive
    {
        void Save(LiveMap liveMap);
        void Delet(int Id);
        LiveMap GetById(int id);
        List<LiveMap> GetListLive();
        List<LiveMap> GetSearchListLive(string text);

    }
}
