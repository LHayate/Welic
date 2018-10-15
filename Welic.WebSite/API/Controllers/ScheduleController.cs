using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Schedule.Dtos;
using Welic.Dominio.Models.Schedule.Services;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/schedule")]
    public class ScheduleController : BaseController
    {
        private IServiceSchedule _serviceSchedule;

        public ScheduleController(IServiceSchedule serviceSchedule)
        {
            _serviceSchedule = serviceSchedule;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.GetById(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListSchedule()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.listSchedule());
        }
       
        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] ScheduleDto scheduleDto)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Save(scheduleDto));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _serviceSchedule.Delete(id);
            return CriaResposta(HttpStatusCode.OK, "Sucess Delete");
        }

    }
}