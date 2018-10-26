using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Dtos;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Menu")]
    public class MenuController : BaseController
    {
        private readonly IServicoMenu _servicoMenu;

        public MenuController(IServicoMenu servicoMenu)
        {
            _servicoMenu = servicoMenu;
        }

        [HttpGet]        
        [Route("GetMenu")]
        public Task<HttpResponseMessage> GetMenu()
        {
            return CriaResposta(HttpStatusCode.OK, _servicoMenu.GetMenuComplet());
        }

        [HttpPost]        
        [Route("GetMenuByUser")]
        public Task<HttpResponseMessage> ListMenuUser([FromBody] UserDto model)
        {
            return CriaResposta(HttpStatusCode.OK, _servicoMenu.GetMenuByUser(model.FirstName));
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
        public Task<HttpResponseMessage> Save([FromBody] MenuDto menuDto)
        {
            _servicoMenu.SaveMenu(menuDto);
            return CriaResposta(HttpStatusCode.OK);
        }

    }
}
