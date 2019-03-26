using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.News.Maps;
using Welic.Dominio.Models.News.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace WebApi.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/News")]
    public class NewsController : BaseController
    {
        private IServiceNews _serviceNews;
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public NewsController(IServiceNews serviceNews, IUnitOfWorkAsync unitOfWorkAsync )
        {
            _serviceNews = serviceNews;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.FindAsync(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListSchedule()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceNews.Query().Select(x=> x).Where(x=> x.Date > DateTime.Now).OrderBy(x=> x.Date).ToList());
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] NewsMap newsMap)
        {
            try
            {
                _serviceNews.Insert(newsMap);
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceNews.Find(newsMap.Id));
            }
            catch (Exception e)
            {
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao Salvar ");
            }            
        }
        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> Update([FromBody] NewsMap newsMap)
        {
            try
            {
                _serviceNews.Update(newsMap);
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceNews.Find(newsMap.Id));
            }
            catch (Exception e)
            {
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao atualizar");
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {                
                _serviceNews.Delete(_serviceNews.Find(id));
                _unitOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, "Excluido com Sucesso");                
            }
            catch (Exception e)
            {
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao deletar");
            }
           
        }
    }
}