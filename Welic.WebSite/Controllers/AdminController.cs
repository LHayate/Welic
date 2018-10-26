using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Models.Users.Entidades;

namespace Welic.WebSite.Controllers
{    
    [Authorize]
    public class AdminController : BaseController
    {
        private IServicoMenu _servicoMenu;
        private IServiceUser _serviceUser;
        public AdminController(IServicoMenu servicoMenu, IServiceUser serviceUser) : base(servicoMenu, serviceUser)
        {
            _servicoMenu = servicoMenu;
            _serviceUser = serviceUser;
        }

        // GET: Dashboard
        //public ActionResult Admin(ComandUser comandUser, string email = null)
        //{
        //    var userfound = _serviceUser.GetByEmail(comandUser.Email??email);
        //    var list = _servicoMenu.GetMenuByUserId(userfound.Id);
        //    return View(list);
        //}
        public ActionResult Admin()
        {
            
            return View();
        }

        public new ActionResult Profile(string email)
        {                        
            var user = _serviceUser.GetByEmail(email);
            return View(user);
        }
       
    }
}
