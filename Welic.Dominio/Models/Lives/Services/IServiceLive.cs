using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Lives.Services
{
    public interface IServiceLive: IService<LiveMap>
    {
        LiveDto Save(LiveDto liveMap);
        void Delet(int id);
        LiveDto GetById(int id);
        ObservableCollection<LiveDto> GetListLive();
        ObservableCollection<LiveDto> GetListByCourse(int id);
        ObservableCollection<LiveDto> GetSearchListLive(string text);
    }
}
