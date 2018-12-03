using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.EBook.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Ebook
{
    public class ServiceEbook: Service<EBookMap>, IServiceEBook
    {
        public ServiceEbook(IRepositoryAsync<EBookMap> repository) : base(repository)
        {
        }
    }
}
