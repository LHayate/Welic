using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Schedule.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/schedule")]
    public class ScheduleController : BaseController
    {
        private IServiceSchedule _serviceSchedule;
        private IUnitOfWorkAsync _unityOfWorkAsync;

        public ScheduleController(IServiceSchedule serviceSchedule, IUnitOfWorkAsync unityOfWorkAsync)
        {
            _serviceSchedule = serviceSchedule;
            _unityOfWorkAsync = unityOfWorkAsync;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<HttpResponseMessage> GetById(int id)
        {            
            return await CriaResposta(HttpStatusCode.OK, _serviceSchedule.Find(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListSchedule()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Query().Select(x=> x).ToList());
        }
        [HttpGet]
        [Route("GetListByUser/{id}")]
        public Task<HttpResponseMessage> ListByUser(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceSchedule.Query().Select(x => x).Where(x=> x.TeacherId == id && x.Ativo).ToList());
        }

        [HttpPost]
        [Route("save")]
        public async  Task<HttpResponseMessage> save([FromBody] ScheduleMap scheduleMap)
        {
            try
            {
                _serviceSchedule.Insert(scheduleMap);
                await _unityOfWorkAsync.SaveChangesAsync();
                return await CriaResposta(HttpStatusCode.OK, _serviceSchedule.Query().Select(x=> x)
                    .FirstOrDefault(x=> x.Title == scheduleMap.Title && 
                                       x.DateEvent == scheduleMap.DateEvent && 
                                       x.Description == scheduleMap.Description && 
                                       x.TeacherId == scheduleMap.TeacherId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return await CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar");
            }            
        }

        [HttpPost]
        [Route("update")]
        public async Task<HttpResponseMessage> Update([FromBody] ScheduleMap scheduleMap)
        {
            try
            {
                _serviceSchedule.Update(scheduleMap);
                await _unityOfWorkAsync.SaveChangesAsync();
                return await CriaResposta(HttpStatusCode.OK, _serviceSchedule.Find(scheduleMap.ScheduleId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return  await CriaResposta(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            _serviceSchedule.Delete(id);
            _unityOfWorkAsync.SaveChangesAsync();
            return CriaResposta(HttpStatusCode.OK, "Sucess Delete");
        }
    }
}