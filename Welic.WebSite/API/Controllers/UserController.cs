using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        public readonly IServiceUser _servico;
        public UserController(IServiceUser servico)
        {
            _servico = servico;
        }
        [HttpGet]
        [Route("getall")]
        public Task<HttpResponseMessage> GetAll()
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetAll());
        }

        [HttpGet]
        //[Route("GetByName/user")]
        public Task<HttpResponseMessage> GetByEmail([FromUri]UserDto user)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetByEmail(user.Email));
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetById(id));
        }


        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> Save([FromBody] UserDto dispositivoDto)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Save(dispositivoDto));

        }        
        [HttpPost]
        [Route("delete/{id:int}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _servico.Delete(id);
            return CriaResposta(HttpStatusCode.OK,"Sucess Delete");

        }
    }
}
