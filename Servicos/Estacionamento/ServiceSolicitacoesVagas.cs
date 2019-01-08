using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Servicos.Estacionamento
{
    public class ServiceSolicitacoesVagas : Service<SolicitacoesVagasMap>, IServiceSolicitacoesVagas
    {
        public ServiceSolicitacoesVagas(IRepositoryAsync<SolicitacoesVagasMap> repository) : base(repository)
        {
        }
    }
}
