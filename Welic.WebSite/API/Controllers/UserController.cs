using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.WebSite.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IServicoLogin _servico;
        public UserController(IServicoLogin servico)
        {
            _servico = servico;
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
