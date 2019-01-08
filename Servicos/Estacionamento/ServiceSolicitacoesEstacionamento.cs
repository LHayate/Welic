using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Estacionamento
{
    public class ServiceSolicitacoesEstacionamento : Service<SolicitacoesEstacionamentoMap>, IServiceSolicitacoesEstacionamento
    {
        public ServiceSolicitacoesEstacionamento(IRepositoryAsync<SolicitacoesEstacionamentoMap> repository) : base(repository)
        {
        }
    }
}
