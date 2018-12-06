using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.EBook.Services;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/ebook")]
    public class EbookController : BaseController
    {
        private IServiceEBook _serviceEBook;
        private IUnitOfWorkAsync _unityOfWorkAsync;

        public EbookController(IServiceEBook serviceEbook, IUnitOfWorkAsync unityOfWorkAsync)
        {
            _serviceEBook = serviceEbook;
            _unityOfWorkAsync = unityOfWorkAsync;
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Find(id));
        }

        [HttpGet]
        [Route("GetList")]
        public Task<HttpResponseMessage> ListLive()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Query().Select(x => x).ToList());
        }

        [HttpGet]
        [Route("GetListRecentes")]
        public Task<HttpResponseMessage> ListLiveRecentes()
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Query().Select(x => x).OrderByDescending(x => x.DateRegister).ToList());
        }

        [HttpGet]
        [Route("GetLisFavoritos")]
        public Task<HttpResponseMessage> ListLivFavoritas()
        {
            //TODO: Implementar Favoritos
            return CriaResposta(HttpStatusCode.NotImplemented, "Implementar");
        }

        [HttpGet]
        [Route("GetListTeacher/{id}")]
        public Task<HttpResponseMessage> ListLivebyTeacher(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Query().Select(x => x).Where(x => x.TeacherId == id).ToList());
        }

        [HttpGet]
        [Route("GetListbyCourse/{id:int}")]
        public Task<HttpResponseMessage> ListbyCourse(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Query().Select(x => x).Where(x => x.CourseId == id).ToList());
        }

        [HttpGet]
        [Route("GetSearchList/{text}")]
        public Task<HttpResponseMessage> ListSearchLive(string text)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceEBook.Query().Select(x => x).Where(x => x.Title.Contains(text) || x.Description.Contains(text)));
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] EBookMap liveDto)
        {
            try
            {
                _serviceEBook.Insert(liveDto);
                _unityOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceEBook.Find(liveDto.Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, $"Erro ao salvar informações{e.Message}-{e.InnerException}");
            }
        }

        [HttpPost]
        [Route("Update")]
        public Task<HttpResponseMessage> Update([FromBody] EBookMap liveDto)
        {
            try
            {
                _serviceEBook.Update(liveDto);
                _unityOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, "Atualizado com Sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar informações");
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                _serviceEBook.Delete(id);
                _unityOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, "Sucess Delete");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, "Erro ao salvar informações");
            }

        }
    }
}
