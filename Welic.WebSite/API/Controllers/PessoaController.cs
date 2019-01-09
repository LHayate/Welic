using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.Client.Service;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Pessoa")]
    public class PessoaController : BaseController
    {
        private IServicePessoa _servicePessoa;
        private IUnitOfWorkAsync _unitOfWorkAsync;
        public PessoaController(IServicePessoa servicePessoa, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _servicePessoa = servicePessoa;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _servicePessoa.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _servicePessoa.Find(id));
        }

        [HttpGet]
        [Route("GetByCpf/{cpf}")]
        public async Task<HttpResponseMessage> GetByCpf(long cpf)
        {
            return await CriaResposta(HttpStatusCode.OK, _servicePessoa.Query().Select(x=> x).FirstOrDefault(x=> x.Cpf == cpf));
        }

        // POST: api/Curso
        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]PessoaMap pessoa)
        {
            _servicePessoa.Insert(pessoa);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _servicePessoa
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.Nome == pessoa.Nome &&
                                    x.NomePai == pessoa.NomePai && 
                                    x.Celular == pessoa.Celular));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]PessoaMap pessoa)
        {
            _servicePessoa.Update(pessoa);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _servicePessoa.Find(pessoa.IdPessoa));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _servicePessoa.Find(id);
            _servicePessoa.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
