using System;
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
    [RoutePrefix("api/Solicitacoes")]
    public class SolicitacaoVagaController : BaseController
    {               

        private readonly IServiceSolicitacoesVagas _serviceSolicitacoesVagas;
        public IServiceEstacionamentoVagas _serviceEstacionamentoVagas;
        private readonly IServiceVeiculo _serviceVeiculo;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public SolicitacaoVagaController(IServiceSolicitacoesVagas serviceSolicitacoesVagas, IUnitOfWorkAsync unitOfWorkAsync, IServiceVeiculo serviceVeiculo, IServiceEstacionamentoVagas serviceEstacionamentoVagas)
        {
            _serviceSolicitacoesVagas = serviceSolicitacoesVagas;
            _serviceEstacionamentoVagas = serviceEstacionamentoVagas;
            _serviceVeiculo = serviceVeiculo;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Query().Select(x => x).ToList());
        }        

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Find(id));
        }

        [HttpGet]
        [Route("GetByUser/{id}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Query().Select(x => x).Where(x => x.IdUser == id).OrderBy(x => x.IdSolicitacao));
        }

        [HttpGet]
        [Route("GetByDate/{date}")]
        public async Task<HttpResponseMessage> GetByDate(DateTime date)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas
                .Query()
                .Select(x => x)
                .Where(x=> x.DtInicio == date)
                .OrderBy(x => x.IdSolicitacao));
        }

        [HttpGet]
        [Route("GetByPessoa/{id:int}")]
        public async Task<HttpResponseMessage> GetByPessoa(int pessoa)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas
                .Query()
                .Select(x => x)
                .Where(x => x.IdPessoa == pessoa)
                .OrderBy(x => x.IdSolicitacao));
        }

        [HttpGet]
        [Route("GetByPlaca/{placa}")]
        public async Task<HttpResponseMessage> GetByPlaca(string placa)
        {
            var veiculo = _serviceVeiculo.Query().Select(s => s).FirstOrDefault(t => t.Placa == placa);

            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas
                .Query()                
                .Select(x => x)                
                .Where(x => x.IdVeiculo == veiculo?.IdVeiculo)
                .OrderBy(x => x.IdSolicitacao));
        }

        [HttpGet]
        [Route("GetEstacionamentoVagas/")]
        public Task<HttpResponseMessage> GetEstacionamentoVagas()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetEstacionamentoVagasById/{id:int}")]
        public async Task<HttpResponseMessage> GetEstacionamentoVagas(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Find(id));
        }



        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]SolicitacoesVagasMap solicitacoes)
        {
            _serviceSolicitacoesVagas.Insert(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.IdPessoa == solicitacoes.IdPessoa &&
                                    x.IdSolicitacao == solicitacoes.IdSolicitacao && 
                                    x.IdVeiculo == solicitacoes.IdVeiculo && 
                                    x.DtInicio == solicitacoes.DtInicio && 
                                    x.DtSolicitacao == solicitacoes.DtSolicitacao && 
                                    x.IdUser == solicitacoes.IdUser));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]SolicitacoesVagasMap solicitacoes)
        {
            _serviceSolicitacoesVagas.Update(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Find(solicitacoes.IdSolicitacao));
        }

        [HttpPost]
        [Route("Cancelar/{id}")]
        public Task<HttpResponseMessage> Cancelar(int id)
        {
            var cursoMap = _serviceSolicitacoesVagas.Find(id);
            cursoMap.Ativo = false;
            _serviceSolicitacoesVagas.Update(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _serviceSolicitacoesVagas.Find(id);
            _serviceSolicitacoesVagas.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }

    }
}
