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


namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/uploads")]
    public class UploadController : BaseController
    {
        private IUploadsService _uploadsService;
        private IServiceUser _serviceUser;

        public UploadController(IUploadsService uploadsService, IServiceUser serviceUser)
        {
            _uploadsService = uploadsService;
            _serviceUser = serviceUser;
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
            // Preparar CustomMultipartFormDataStreamProvider para carga de dados
            // (veja mais abaixo)

            string fileSaveLocation = HttpContext.Current.Server.MapPath("~/Arquivos/Uploads");
            CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(fileSaveLocation);
            List<string> files = new List<string>();
            try
            {
                // Ler conteúdo da requisição para CustomMultipartFormDataStreamProvider. 

                await Request.Content.ReadAsMultipartAsync(provider);                
                foreach (MultipartFileData file in provider.FileData)
                {                    
                    files.Add(Path.GetFileName(file.LocalFileName));
                    File.Move(file.LocalFileName, 
                        Path.Combine(
                            CriarDiretorioSeNaoExistir(Path.Combine("~/Arquivos/Uploads", file.LocalFileName)),
                            file.LocalFileName
                            )
                        );

                    var user = _serviceUser.GetById(file.LocalFileName.Split('_')[2]);
                    _uploadsService.Insert(new UploadsMap
                    {
                        ObjectState = ObjectState.Added,
                        Path = Path.Combine(
                                CriarDiretorioSeNaoExistir(Path.Combine("~/Arquivos/Uploads", file.LocalFileName)),
                                file.LocalFileName ),
                        UploadId = new Guid(), 
                        User = new AspNetUser()
                        {
                            ObjectState = ObjectState.Unchanged,
                            FirstName = user.FirstName,
                            NickName = user.NickName,
                            Guid = user.Guid,
                            LastName = user.LastName,
                            Email = user.Email,                                                        
                        }
                    });
                }
                                
                // OK se tudo deu certo.
                return await CriaResposta(HttpStatusCode.OK, files);
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
