using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Curso.Service;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/curso")]
    public class CursoController : BaseController
    {
        private ICursoService _cursoService;
        private IUnitOfWorkAsync _unityOfWorkAsync;

        public CursoController(ICursoService cursoService, IUnitOfWorkAsync unityOfWorkAsync)
        {
            _cursoService = cursoService;
            _unityOfWorkAsync = unityOfWorkAsync;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _cursoService.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _cursoService.FindAsync(id));
        }

        [HttpGet]
        [Route("GetByUser/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            //DB.Places.Include(z => z.Images).Where(x => x.CityId == CityId).ToList();
            return CriaResposta(HttpStatusCode.OK, _cursoService.Query()                             
                .Select(x => x )                
                .Where(x=> x.AuthorId == id)
                .ToList());
        }

        // POST: api/Curso
        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]CursoMap cursoMap)
        {
            _cursoService.Insert(cursoMap);
            await _unityOfWorkAsync.SaveChangesAsync();
            return  await CriaResposta(HttpStatusCode.OK);
        }

        // PUT: api/Curso/5
        [HttpPut]
        [Route("Edite")]
        public Task<HttpResponseMessage> Put([FromBody]CursoMap cursoMap)
        {
            _cursoService.Update(cursoMap);
            _unityOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }

        // DELETE: api/Curso/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public void Delete(int id)  
        {
            var cursoMap = _cursoService.Find(id);            
            _cursoService.Delete(cursoMap);
            _unityOfWorkAsync.SaveChangesAsync();
        }
    }
}
