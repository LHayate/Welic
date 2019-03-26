using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Eventos;

namespace WebApi.API.Controllers
{
    public class BaseController : ApiController
    {
        public readonly IManipulador<NotificacaoDominio> Notificacoes;
        public HttpResponseMessage Resposta;
        public BaseController()
        {
            Notificacoes = EventoDominio.Container.ObterServico<IManipulador<NotificacaoDominio>>();
            Resposta = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CriaResposta(HttpStatusCode code, object result)
        {
            Resposta = Notificacoes.PossuiNotificacoes()
                ? Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = Notificacoes.Notificar() })
                : Request.CreateResponse(code, result);
            Resposta =  Request.CreateResponse(code, result);

            return Task.FromResult(Resposta);
        }

        public Task<HttpResponseMessage> CriaResposta(HttpStatusCode code)
        {
            Resposta = Request.CreateResponse(code);

            return Task.FromResult(Resposta);
        }
    }
}
