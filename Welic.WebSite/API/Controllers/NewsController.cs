using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.News.Dtos;
using Welic.Dominio.Models.News.Services;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/News")]
    public class NewsController : BaseController
    {
        private IServiceNews _serviceNews;

        public NewsController(IServiceNews serviceNews)
        {
            _serviceNews = serviceNews;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.GetById(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListSchedule()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.GetList());
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] NewsDto scheduleDto)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.Save(scheduleDto));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.Delete(id) ? "Sucess Delete" : "Error Delete");
        }
    }
}