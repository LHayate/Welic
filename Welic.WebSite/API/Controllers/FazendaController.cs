using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dominio.Models.Fazenda.Map;
using Dominio.Models.Fazenda.Service;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace WebApi.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/fazenda")]
    public class FazendaController : BaseController
    {
        private readonly IServiceFazenda _serviceFazenda;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public FazendaController(IServiceFazenda serviceFazenda, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _serviceFazenda = serviceFazenda;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceFazenda.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceFazenda.Find(id));
        }

        [HttpGet]
        [Route("GetByUser/{id}")]
        public async Task<HttpResponseMessage> GetByPessoa(string id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceFazenda.Query().Select(x => x).FirstOrDefault(x => x.IdUser == id));
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] FazendasMap fazenda)
        {
            try
            {
                _serviceFazenda.Insert(fazenda);
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceFazenda.Find(fazenda.Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, $"Erro ao salvar informações{e.Message}-{e.InnerException}");
            }
        }

        [HttpPost]
        [Route("Update")]
        public Task<HttpResponseMessage> Update([FromBody] FazendasMap map)
        {
            try
            {
                _serviceFazenda.Update(map);
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceFazenda.Find(map.Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar informações");
            }

        }

        [HttpPost]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                _serviceFazenda.Delete(id);
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, "Sucess Delete");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar informações");
            }

        }
    }
}
