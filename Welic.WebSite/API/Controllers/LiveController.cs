using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Welic.Dominio.Models.Lives.Dtos;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/live")]
    public class LiveController : BaseController
    {
        private IServiceLive _serviceLive;
        private IUnitOfWorkAsync _unityOfWorkAsync;

        public LiveController(IServiceLive serviceLive, IUnitOfWorkAsync unityOfWorkAsync)
        {
            _serviceLive = serviceLive;
            _unityOfWorkAsync = unityOfWorkAsync;
        }

        //public async void WriteContentToStream(Stream outputStream, HttpContent content, TransportContext transportContext)
        //{
        //    //path of file which we have to read//  
        //    var filePath = HttpContext.Current.Server.MapPath("~/LVJZ0375.MP4");
        //    //here set the size of buffer, you can set any size  
        //    int bufferSize = 1000;
        //    byte[] buffer = new byte[bufferSize];
        //    //here we re using FileStream to read file from server//  
        //    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        int totalSize = (int)fileStream.Length;
        //        /*here we are saying read bytes from file as long as total size of file 

        //        is greater then 0*/
        //        while (totalSize > 0)
        //        {
        //            int count = totalSize > bufferSize ? bufferSize : totalSize;
        //            //here we are reading the buffer from orginal file  
        //            int sizeOfReadedBuffer = fileStream.Read(buffer, 0, count);
        //            //here we are writing the readed buffer to output//  
        //            await outputStream.WriteAsync(buffer, 0, sizeOfReadedBuffer);
        //            //and finally after writing to output stream decrementing it to total size of file.  
        //            totalSize -= sizeOfReadedBuffer;
        //        }
        //    }
        //}

        //public HttpResponseMessage GetVideoContent()
        //{
        //    var httpResponce = Request.CreateResponse();
        //    httpResponce.Content = new PushStreamContent((Action<Stream, HttpContent, TransportContext>)WriteContentToStream);
        //    return httpResponce;
        //}
        
        [HttpGet]
        [Route("GetById/{id:int}")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceLive.GetById(id));
        }

        [HttpGet]
        [Route("GetListLive")]
        public Task<HttpResponseMessage> ListLive()
        {            
            return CriaResposta(HttpStatusCode.OK, _serviceLive.GetListLive());
        }

        [HttpGet]
        [Route("GetListbyCourse/{id:int}")]
        public Task<HttpResponseMessage> ListbyCourse(int id)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceLive.GetListByCourse(id));
        }

        [HttpGet]
        [Route("GetSearchListLive/{text}")]
        public Task<HttpResponseMessage> ListSearchLive(string text)
        {
            return CriaResposta(HttpStatusCode.OK, _serviceLive.GetSearchListLive(text));
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> save([FromBody] LiveMap liveDto)
        {
            try
            {
                _serviceLive.Insert(liveDto);
                _unityOfWorkAsync.SaveChanges();
                return CriaResposta(HttpStatusCode.OK, _serviceLive.Find(liveDto.Id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.BadRequest, $"Erro ao salvar informações{e.Message}-{e.InnerException}");
            }            
        }

        [HttpPost]
        [Route("Update")]
        public Task<HttpResponseMessage> Update([FromBody] LiveMap liveDto)
        {
            try
            {
                _serviceLive.Update(liveDto);
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
                _serviceLive.Delet(id);
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
