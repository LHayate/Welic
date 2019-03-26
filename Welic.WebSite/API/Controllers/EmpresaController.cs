using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Empresa.Service;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace WebApi.API.Controllers
{
    
    [RoutePrefix("api/empresas")]
    public class EmpresaController : BaseController
    {
        private readonly IServiceEmpresa _service;
        private readonly IServiceUser _serviceUser;
        private IUnitOfWorkAsync _unitOfWorkAsync;
        public EmpresaController(IServiceEmpresa service, IUnitOfWorkAsync unitOfWorkAsync, IServiceUser serviceUser)
        {
            _service = service;
            _serviceUser = serviceUser;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("Get")]
        public Task<HttpResponseMessage> Listar()
        {
            return CriaResposta(HttpStatusCode.OK, _service.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Authorize]
        [Route("Getbyid/{id:int}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            return  CriaResposta(HttpStatusCode.OK, _service.Find(id));
        }

        [HttpGet]
        [Authorize]
        [Route("ValidaEmpresa/{email}/{id:int}")]
        public Task<HttpResponseMessage> ValidaEmpresa(int id, string email)
        {
            
            return CriaResposta(HttpStatusCode.OK, _serviceUser.Query().Select(x=> x).Any(x=> x.Email == email /*&& x.EmpresaId == id*/));
        }

        //[HttpGet]
        //[Route("GetbyUser/id")]
        //public Task<HttpResponseMessage> ListarPorUsuario(string id)
        //{            
        //    //return CriaResposta(HttpStatusCode.OK, _service.ListarPorUsuario(User.Identity.Name));
        //}
    }
}
