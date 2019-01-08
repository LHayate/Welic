using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Live
{
    public class ServiceFavoriteLive : Service<FavoriteLiveMap>, IServiceFavoriteLive
    {
        public ServiceFavoriteLive(IRepositoryAsync<FavoriteLiveMap> repository) 
            : base(repository)
        {

        }
    }
}
