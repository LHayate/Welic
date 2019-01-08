using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.City.Map;
using Welic.Dominio.Models.City.Service;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/City")]
    public class CidadeController : BaseController
    {
        private IServiceCity _serviceCity;
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public CidadeController(IServiceCity serviceCity, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _serviceCity = serviceCity;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceCity.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _serviceCity.Find(id));
        }

        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]CityMap pessoa)
        {
            _serviceCity.Insert(pessoa);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceCity
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.Nome == pessoa.Nome &&
                                    x.Cep == pessoa.Cep &&
                                    x.Estado == pessoa.Estado));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]CityMap pessoa)
        {
            _serviceCity.Update(pessoa);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _serviceCity.Find(pessoa.IdCity));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _serviceCity.Find(id);
            _serviceCity.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
