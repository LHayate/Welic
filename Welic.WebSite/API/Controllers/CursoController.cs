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
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _cursoService.Find(id));
        }

        [HttpGet]
        [Route("GetByUser/{id}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            //DB.Places.Include(z => z.Images).Where(x => x.CityId == CityId).ToList();
            return await CriaResposta(HttpStatusCode.OK, _cursoService.Query()                             
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
            return  await CriaResposta(HttpStatusCode.OK, _cursoService
                .Query()
                .Select(x=> x)
                .LastOrDefault(x=> x.Description == cursoMap.Description && 
                                    x.Title == cursoMap.Title && 
                                    x.AuthorId == cursoMap.AuthorId));
        }
        
        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]CursoMap cursoMap)
        {
            _cursoService.Update(cursoMap);
            await _unityOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _cursoService.Find(cursoMap.IdCurso));
        }
        
        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)  
        {
            var cursoMap = _cursoService.Find(id);            
            _cursoService.Delete(cursoMap);
            _unityOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
