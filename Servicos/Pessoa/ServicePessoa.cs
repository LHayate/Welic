using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.Client.Service;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Pessoa
{
    public class ServicePessoa: Service<PessoaMap>, IServicePessoa
    {
        public ServicePessoa(IRepositoryAsync<PessoaMap> repository) : base(repository)
        {
        }
    }
}
