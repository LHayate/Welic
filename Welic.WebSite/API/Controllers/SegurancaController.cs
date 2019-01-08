using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Segurança.Service;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/seguranca")]
    public class SegurancaController : BaseController
    {
        private IServicePermission _servicePermission;

        public SegurancaController(IServicePermission servicePermission)
        {
            _servicePermission = servicePermission;

        }

        [HttpGet]
        [Route("Get")]
        public Task<HttpResponseMessage> Listar()
        {
            return CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("Get/{id}")]
        public Task<HttpResponseMessage> GetById(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("Get/{id}/{program}")]
        public Task<HttpResponseMessage> BuscarPermission(string id, int program)
        {
            return CriaResposta(HttpStatusCode.OK, _servicePermission.Query().Select(x => x).ToList());
        }
    }
}
