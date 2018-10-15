using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Dtos;

namespace Welic.Dominio.Models.Lives.Services
{
    public interface IServiceLive
    {
        LiveDto Save(LiveDto liveMap);
        void Delet(int id);
        LiveDto GetById(int id);
        ObservableCollection<LiveDto> GetListLive();
        ObservableCollection<LiveDto> GetSearchListLive(string text);
    }
}
