using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.Client.Service;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Segurança.Service;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace WebApi.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/permission")]
    public class PermissionController : BaseController
    {
        private IServicePermission _servicePermission;
        private IUnitOfWorkAsync _unitOfWorkAsync;
        public PermissionController(IServicePermission servicePermission, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _servicePermission = servicePermission;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get/")]
        public Task<HttpResponseMessage> Get()
        {
            return CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return await CriaResposta(HttpStatusCode.OK, _servicePermission.Find(id));
        }

        [HttpGet]
        [Route("GetByUser/{id}")]
        public async Task<HttpResponseMessage> Get(string id)
        {
            return await CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x=> x).Where(x=> x.IdUser == id).OrderBy(x=> x.IdPermissao));
        }

        [HttpGet]
        [Route("GetByUserProgram/{id}/{program}")]
        public async Task<HttpResponseMessage> Get(string id, int program)
        {
            return await CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x => x).Where(x => x.IdUser == id && x.IdProgram == program).OrderBy(x => x.IdPermissao));
        }

        // POST: api/Curso
        [HttpPost]
        [Route("save")]
        public async Task<HttpResponseMessage> Post([FromBody]PermissionMap permission)
        {
            _servicePermission.Insert(permission);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _servicePermission
                .Query()
                .Select(x => x)
                .LastOrDefault(x => x.IdProgram == permission.IdProgram &&
                                    x.IdUser == permission.IdUser));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<HttpResponseMessage> Update([FromBody]PermissionMap permission)
        {
            _servicePermission.Update(permission);
            await _unitOfWorkAsync.SaveChangesAsync();
            return await CriaResposta(HttpStatusCode.OK, _servicePermission.Find(permission.IdPermissao));
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            var cursoMap = _servicePermission.Find(id);
            _servicePermission.Delete(cursoMap);
            _unitOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK);
        }
    }
}
