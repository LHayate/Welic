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
        private readonly IServiceEstacionamentoVagas _serviceEstacionamentoVagas;
        private readonly IServiceSolicitacoesVagasLiberada _serviceSolicitacoesVagasLiberada;
        private readonly IServiceSolicitacoesEstacionamento _serviceSolicitacoesEstacionamento;
        private readonly IServiceVeiculo _serviceVeiculo;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public SolicitacaoVagaController(IServiceSolicitacoesVagas serviceSolicitacoesVagas, 
            IUnitOfWorkAsync unitOfWorkAsync, IServiceVeiculo serviceVeiculo, IServiceEstacionamentoVagas serviceEstacionamentoVagas, 
            IServiceSolicitacoesVagasLiberada solicitacoesVagasLiberada, IServiceSolicitacoesEstacionamento serviceSolicitacoesEstacionamento)
        {
            _serviceSolicitacoesVagas = serviceSolicitacoesVagas;
            _serviceEstacionamentoVagas = serviceEstacionamentoVagas;
            _serviceSolicitacoesVagasLiberada = solicitacoesVagasLiberada;
            _serviceSolicitacoesEstacionamento = serviceSolicitacoesEstacionamento;
            _serviceVeiculo = serviceVeiculo;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        #region Solicitacoes Vagas 

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
        #endregion

        #region Solicitacoes VagasLiberadas       

        [HttpGet]
        [Route("GetVagasLiberadas/")]
        public Task<HttpResponseMessage> GetVagasLiberadas()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetVagasLiberadasById/{id:int}")]
        public async Task<HttpResponseMessage> GetVagasLiberadas(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada.Find(id));
        }

        [HttpGet]
        [Route("GetVagasLiberadasByUser/{id}")]
        public async Task<HttpResponseMessage> GetVagasLiberadas(string id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada.Query().Select(x => x).Where(x => x.IdUser == id).OrderBy(x => x.Vaga));
        }

        [HttpGet]
        [Route("GetVagasLiberadasByDate/{date}")]
        public async Task<HttpResponseMessage> GetVagasLiberadasByDate(DateTime date)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada
                .Query()
                .Select(x => x)
                .Where(x => x.DtLiberacao == date)
                .OrderBy(x => x.Vaga));
        }

        [HttpGet]
        [Route("GetVagasLiberadasByEstacionamento/{estacionamento}")]
        public async Task<HttpResponseMessage> GetVagasLiberadasByPessoa(int estacionamento)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada
                .Query()
                .Select(x => x)
                .Where(x => x.IdEstacionamento == estacionamento)
                .OrderBy(x => x.Vaga));
        }

        

        [HttpGet]
        [Route("GetVagasLiberadasByPlaca/{placa}")]
        public async Task<HttpResponseMessage> GetVagasLiberadasByPlaca(string placa)
        {
            var veiculo = _serviceVeiculo.Query().Select(s => s).FirstOrDefault(t => t.Placa == placa);

            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada
                .Query()
                .Select(x => x)
                .Where(x => x.IdVeiculo == veiculo?.IdVeiculo)
                );
        }               


        [HttpPost]
        [Route("saveVagasLiberadas")]
        public async Task<HttpResponseMessage> Post([FromBody]SolicitacoesVagasLiberadasMap solicitacoes)
        {
            _serviceSolicitacoesVagasLiberada.Insert(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagasLiberada
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.IdEstacionamento == solicitacoes.IdEstacionamento &&
                                    x.IdVeiculo == solicitacoes.IdVeiculo &&
                                    x.Situacao == solicitacoes.Situacao &&
                                    x.Vaga == solicitacoes.Vaga));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]SolicitacoesVagasLiberadasMap solicitacoes)
        {
            _serviceSolicitacoesVagasLiberada.Update(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesVagas.Find(solicitacoes.Vaga));
        }

        [HttpPost]
        [Route("CancelarVagasLiberadas/{id}")]
        public Task<HttpResponseMessage> CancelarVagasLiberadas(int id)
        {
            var cursoMap = _serviceSolicitacoesVagasLiberada.Find(id);            
            _serviceSolicitacoesVagasLiberada.Update(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }


        [HttpPost]
        [Route("DeleteVagasLiberadas/{id}")]
        public Task<HttpResponseMessage> DeleteVagasLiberadas(int id)
        {
            var cursoMap = _serviceSolicitacoesVagas.Find(id);
            _serviceSolicitacoesVagas.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
        #endregion

        #region SolicitacoesEstacionamento

        [HttpGet]
        [Route("GetSolicitacoesEstacionamento/")]
        public Task<HttpResponseMessage> GetSolicitacoesEstacionamento()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetSolicitacoesEstacionamentoById/{id:int}")]
        public async Task<HttpResponseMessage> GetSolicitacoesEstacionamento(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento.Find(id));
        }            

        [HttpGet]
        [Route("GetSolicitacoesEstacionamentoByEstacionamento/{estacionamento}")]
        public async Task<HttpResponseMessage> GetSolicitacoesEstacionamentoByEstacionamento(int estacionamento)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento
                .Query()
                .Select(x => x)
                .Where(x => x.Estacionamento == estacionamento)
                .OrderBy(x => x.Vaga));
        }

        [HttpGet]
        [Route("GetSolicitacoesEstacionamentoByEstacionamento/{estacionamento}/{solicitacao}")]
        public async Task<HttpResponseMessage> GetVagasLiberadasByEstacionamento(int estacionamento, int solicitacao)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento
                .Query()
                .Select(x => x)
                .Where(x => x.Estacionamento == estacionamento && x.Solicitacao == solicitacao)
                .OrderBy(x => x.Vaga));
        }

        [HttpPost]
        [Route("SaveEstacionamento")]
        public async Task<HttpResponseMessage> Post([FromBody]SolicitacoesEstacionamentoMap solicitacoes)
        {
            _serviceSolicitacoesEstacionamento.Insert(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.Estacionamento == solicitacoes.Estacionamento &&
                                    x.Situacao == solicitacoes.Situacao &&
                                    x.Vaga == solicitacoes.Vaga &&
                                    x.Solicitacao == solicitacoes.Solicitacao));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]SolicitacoesEstacionamentoMap solicitacoes)
        {
            _serviceSolicitacoesEstacionamento.Update(solicitacoes);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceSolicitacoesEstacionamento.Find(solicitacoes.Vaga));
        }        


        [HttpPost]
        [Route("DeleteSolicitacoesEstacionamento/{id}")]
        public Task<HttpResponseMessage> DeleteSolicitacoesEstacionamento(int id)
        {
            var cursoMap = _serviceSolicitacoesEstacionamento.Find(id);
            _serviceSolicitacoesEstacionamento.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }

        #endregion


        
    }
}
