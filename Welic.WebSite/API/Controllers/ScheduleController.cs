using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Schedule.Maps;
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
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.FindAsync(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListSchedule()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Query().Select(x=> x).ToList());
        }
       
        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] ScheduleMap scheduleMap)
        {
            try
            {
                _serviceSchedule.Insert(scheduleMap);
                return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Find(scheduleMap.ScheduleId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar");
            }            
        }

        [HttpPost]
        [Route("update")]
        public Task<HttpResponseMessage> Update([FromUri] ScheduleMap scheduleMap)
        {
            try
            {
                _serviceSchedule.Update(scheduleMap);
                return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Find(scheduleMap.ScheduleId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar");
            }
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