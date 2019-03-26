using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Lives.Services;

namespace WebApi.API.Controllers
{
    public class FavoritesController : BaseController
    {
        private IServiceFavoriteLive _serviceFavoriteLive;

        public FavoritesController(IServiceFavoriteLive serviceFavoriteLive)
        {
            _serviceFavoriteLive = serviceFavoriteLive;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceFavoriteLive.Find(id));
        }

        [HttpGet]
        [Route("GetByLive/{id}")]
        public Task<HttpResponseMessage> GetByLive(int id)
        {

            return CriaResposta(HttpStatusCode.OK, _serviceFavoriteLive.Query().Select(x=> x).Where(x=> x.IdLive == id));

        }
    }
}
