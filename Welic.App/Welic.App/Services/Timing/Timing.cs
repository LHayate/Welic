using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.App.Models.Dispositivos.Dto;
using Welic.App.Models.Usuario;
using Welic.App.Services.ServiceViews;

namespace Welic.App.Services.Timing
{
    public class Timing : ITiming
    {
        private DatabaseManager _dbManager;
        public Task<bool> SendNewData()
        {
            throw new NotImplementedException();
        }

        public bool ConsultDataNoTiming()
        {
            _dbManager = new DatabaseManager();            

            return DateTime.Now.AddHours(-24) <= _dbManager.database.Table<DispositivoDto>().ToList().FirstOrDefault().DateLastSynced;
        }

        public async  Task SincDatas()
        {
            _dbManager = new DatabaseManager();
           
                if (_dbManager.database.Table<UserDto>().Where(dto => dto.Synced == false).ToList().Count > 0)
                    if(!await (new UserDto()).SyncedUser())
                        throw  new System.Exception("Dados de Usuario não Sincronizados");                        
            
        }
    }
}
