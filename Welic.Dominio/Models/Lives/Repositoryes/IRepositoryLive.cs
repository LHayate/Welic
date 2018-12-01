using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;

namespace Welic.Dominio.Models.Lives.Repositoryes
{
    public interface IRepositoryLive
    {
        void Save(LiveMap liveMap);
        void Delet(int Id);
        LiveMap GetById(int id);
        List<LiveMap> GetListLive();
        List<LiveMap> GetListByCourse(int id);
        List<LiveMap> GetSearchListLive(string text);

    }
}
