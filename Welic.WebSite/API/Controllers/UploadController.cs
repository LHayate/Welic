using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Uploads.Services;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;


namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/uploads")]
    public class UploadController : BaseController
    {
        private IUploadsService _uploadsService;
        private IAspNetUserService _serviceUser;
        private IUnitOfWorkAsync _unityOfWorkAsync;
        public UploadController(IUploadsService uploadsService, IAspNetUserService serviceUser, IUnitOfWorkAsync unityOfWorkAsync)
        {
            _serviceUser = serviceUser;
            _uploadsService = uploadsService;
            _unityOfWorkAsync = unityOfWorkAsync;
        }
        [HttpPost]
        [Route("files")]       
        public async Task<HttpResponseMessage> Post()
        {            

            // Ver se POST é MultiPart? 
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            
            try
            {   
                // Preparar CustomMultipartFormDataStreamProvider para carga de dados
                // (veja mais abaixo)
                string fileSaveLocation = HttpContext.Current.Server.MapPath("~/Arquivos/Uploads");
                CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(fileSaveLocation);
                List<string> files = new List<string>();

                // Ler conteúdo da requisição para CustomMultipartFormDataStreamProvider. 
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    
                    files.Add(Path.GetFileName(file.LocalFileName));

                    var path = Path.Combine(
                        CriarDiretorioSeNaoExistir(Path.Combine("~/Arquivos/Uploads",
                            file.LocalFileName.Split('.').LastOrDefault())),
                        file.LocalFileName.Split('/').LastOrDefault());


                    if (path.Contains("Video-"))
                    {
                        var imagem = HttpContext.Current.Server.MapPath($"~/Arquivos/Uploads") +
                                     $"\\{file.LocalFileName.Split('\\').LastOrDefault().Split('.').FirstOrDefault()}.jpg";


                        string executavel = Path.Combine(HttpContext.Current.Server.MapPath("~/ffmpeg/bin/ffmpeg.exe"));
                        string parametros = " -y -i " + path +
                                            " -vframes 1 -ss 00:00:03 -an -vcodec mjpeg -f rawvideo " + imagem;
                        System.Diagnostics.Process.Start(@executavel, parametros);
                    }

                    var user = await _serviceUser.FindAsync(
                        file.LocalFileName.Split('/').LastOrDefault().Split('_')[1]);

                    //user.ObjectState = ObjectState.Unchanged;

                    //Salvar Uploads
                    _uploadsService.Insert(
                        new UploadsMap
                        {
                            ObjectState = ObjectState.Added,
                            Path = path,
                            UploadId = Guid.NewGuid(),                            
                            UserId = user.Id
                        });
                    _unityOfWorkAsync.SaveChanges();
                }
                // OK se tudo deu certo.
                return Request.CreateResponse(HttpStatusCode.OK, files);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        private String CriarDiretorioSeNaoExistir(string path)
        {
            var returnPath = HttpContext.Current.Server.MapPath(path);

            if (!Directory.Exists(returnPath))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));

            return returnPath;
        }
    }

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath)
            : base(rootPath) { }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var filename = headers.ContentDisposition.FileName;

            return !string.IsNullOrWhiteSpace(filename) ?
                filename.Replace("\"", string.Empty) :
            Guid.NewGuid().ToString();
        }
    }

   
}
