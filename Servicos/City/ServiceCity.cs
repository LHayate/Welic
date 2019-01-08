using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.City.Map;
using Welic.Dominio.Models.City.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.City
{
    public class ServiceCity :Service<CityMap>, IServiceCity
    {
        public ServiceCity(IRepositoryAsync<CityMap> repository) : base(repository)
        {
        }
    }
}
