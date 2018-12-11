using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;
using Welic.Repositorios;


namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Menu")]
    public class MenuController : BaseController
    {
        private readonly IServicoMenu _servicoMenu;
        private readonly IServiceUser _serviceUser;
        private IUnitOfWorkAsync _unitOfWorkAsync;

        public MenuController(IServicoMenu servicoMenu, IServiceUser serviceUser, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _servicoMenu = servicoMenu;
            _serviceUser = serviceUser;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]        
        [Route("GetMenu")]
        public Task<HttpResponseMessage> GetMenu()
        {
            return CriaResposta(HttpStatusCode.OK, _servicoMenu.Query().Select(x => x).ToList());
        }

        [HttpPost]        
        [Route("GetMenuByUser")]
        public Task<HttpResponseMessage> ListMenuUser([FromBody] AspNetUser model)
        {

            string query = Query.Q001;

            var usuario = _serviceUser.Query().Select(x => x).FirstOrDefault(x => x.Email == model.Email);            

            return CriaResposta(HttpStatusCode.OK, _servicoMenu.SelectQuery(query, new SqlParameter("IdUser", usuario.Id)).ToList());                        
        }

        [HttpPost]        
        [Route("savetouser")]
        public Task<HttpResponseMessage> SaveMenuUsers([FromBody] CommandMenu commandMenu)
        {
            _servicoMenu.SaveMenuUser(commandMenu);
            return CriaResposta(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("save")]
        public Task<HttpResponseMessage> Save([FromBody] MenuMap menuDto)
        {
            _servicoMenu.Insert(menuDto);
            _unitOfWorkAsync.SaveChanges();
            return CriaResposta(HttpStatusCode.OK);
        }

    }
}
