using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/estacionamento")]
    public class EstacionamentoController : BaseController
    {
        private readonly IServiceEstacionamento _serviceEstacionamento;
        private readonly IServiceEstacionamentoVagas _serviceEstacionamentoVagas;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public EstacionamentoController(IServiceEstacionamento serviceEstacionamento, IUnitOfWorkAsync unitOfWorkAsync, IServiceEstacionamentoVagas serviceEstacionamentoVagas)
        {
            _serviceEstacionamento = serviceEstacionamento;
            _serviceEstacionamentoVagas = serviceEstacionamentoVagas;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEstacionamento.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamento.Find(id));
        }

        [HttpGet]
        [Route("GetVagasByEstacionamento/{id:int}")]
        public async Task<HttpResponseMessage> GetVagas(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamentoVagas.Query().Select(x=> x).Where(x=> x.IdEstacionamento == id).ToList());
        }

        [HttpGet]
        [Route("GetListVagas/{id:int}")]
        public async Task<HttpResponseMessage> GetListVagas(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamentoVagas.Query().Select(x => x).Where(x => x.IdEstacionamento == id).ToList());
        }


        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]EstacionamentoMap estacionamento)
        {
            _serviceEstacionamento.Insert(estacionamento);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamento
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.Descricao == estacionamento.Descricao && 
                                    x.ValidaVencimento == estacionamento.ValidaVencimento && 
                                    x.Relacao == estacionamento.Relacao && 
                                    x.TipoIdentificacao == estacionamento.TipoIdentificacao ));
        }
        
        [HttpPost]
        [Route("saveVagas")]
        public async Task<HttpResponseMessage> Post([FromBody]EstacionamentoVagasMap estacionamento)
        {
            _serviceEstacionamentoVagas.Insert(estacionamento);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamentoVagas
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.IdEstacionamento == estacionamento.IdEstacionamento && 
                                    x.Quantidade == estacionamento.Quantidade && 
                                    x.TipoVaga == estacionamento.TipoVaga && 
                                    x.TipoVeiculo == estacionamento.TipoVeiculo));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]EstacionamentoMap estacionamento)
        {
            _serviceEstacionamento.Update(estacionamento);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceEstacionamento.Find(estacionamento.IdEstacionamento));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _serviceEstacionamento.Find(id);
            _serviceEstacionamento.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("DeleteVagas/{id}/{tipoVaga}/{tipoVeiculo}")]
        public Task<HttpResponseMessage> DeleteVagas(int id, int tipoVaga, int tipoVeiculo)
        {
            var cursoMap = _serviceEstacionamentoVagas.Query().Select(x=> x).FirstOrDefault(x=> x.IdEstacionamento == id && x.TipoVaga == tipoVaga && x.TipoVeiculo == tipoVeiculo);
            _serviceEstacionamentoVagas.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
