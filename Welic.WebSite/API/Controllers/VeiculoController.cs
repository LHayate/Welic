using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/Veiculo")]
    public class VeiculoController : BaseController
    {
       
        private readonly IServiceVeiculo _serviceVeiculo;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public VeiculoController( IUnitOfWorkAsync unitOfWorkAsync, IServiceVeiculo serviceVeiculo)
        {            
            _serviceVeiculo = serviceVeiculo;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceVeiculo.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceVeiculo.Find(id));
        }

        [HttpGet]
        [Route("GetBypessoa/{id}")]
        public async Task<HttpResponseMessage> GetByPessoa(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceVeiculo.Query().Select(x => x).FirstOrDefault(x => x.IdPessoa == id));
        }
             
        [HttpGet]
        [Route("GetByPlaca/{placa}")]
        public async Task<HttpResponseMessage> GetByPlaca(string placa)
        {            
            return await CriaResposta(HttpStatusCode.OK, _serviceVeiculo
                .Query()
                .Select(x => x)
                .Where(x => x.Placa == placa));
        }

        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]VeiculosMap veiculo)
        {
            _serviceVeiculo.Insert(veiculo);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceVeiculo
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.IdPessoa == veiculo.IdPessoa &&                                    
                                    x.IdVeiculo == veiculo.IdVeiculo &&
                                    x.CNH == veiculo.CNH &&
                                    x.Chassi == veiculo.Chassi
                                    ));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]VeiculosMap veiculo)
        {
            _serviceVeiculo.Update(veiculo);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceVeiculo.Find(veiculo.IdVeiculo));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _serviceVeiculo.Find(id);
            _serviceVeiculo.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
