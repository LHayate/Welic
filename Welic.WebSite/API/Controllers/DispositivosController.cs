using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Acesso.Dtos;
using Welic.Dominio.Models.Acesso.Servicos;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Dispositivo")]
    public class DispositivosController : BaseController
    {
        public readonly IServicoDispositivo _servico;
        public DispositivosController(IServicoDispositivo servico)
        {
            _servico = servico;
        }

        [HttpGet]        
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.ConsultarPorId(id));
        }

        [HttpPost]
        [Route("salvar")]
        public Task<HttpResponseMessage> salvar([FromBody] DispositivoDto dispositivoDto)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Salvar(dispositivoDto));

        }

        [HttpPost]
        [Route("alterar")]
        public Task<HttpResponseMessage> Alterar([FromBody]DispositivoDto dispositivoDto)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Alterar(dispositivoDto));

        }
       
    }
}
