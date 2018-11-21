﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Registrators;
using Registrators.Helpers;
using Welic.Dominio.Enumerables;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.ViewModels;
using Welic.WebSite.Models;
using Welic.WebSite.Utilities;

namespace Welic.WebSite.API.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        public readonly IServiceUser _servico;

        #region Fields
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private readonly IEmailTemplateService _emailTemplateService;
        #endregion

        #region Properties
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion

        public UserController(IServiceUser servico)
        {
            _servico = servico;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("getall")]
        public Task<HttpResponseMessage> GetAll()
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetAll());
        }

        [System.Web.Http.HttpGet]
        //[Route("GetByName/user")]
        public Task<HttpResponseMessage> GetByEmail([FromUri]UserDto user)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetByEmail(user.Email));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.GetById(id));
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("save")]
        public Task<HttpResponseMessage> Save([FromBody] UserDto userDto)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Save(userDto));
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Create")]
        public async  Task<HttpResponseMessage> Create([FromBody] AspNetUser model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegisterDate = DateTime.Now,
                    RegisterIP = System.Web.HttpContext.Current.Request.GetVisitorIP(),
                    LastAccessDate = DateTime.Now,
                    LastAccessIP = System.Web.HttpContext.Current.Request.GetVisitorIP()
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    return await CriaResposta(HttpStatusCode.OK, _servico.GetByEmail(user.Email));
                    //// Send Message
                    //var roleAdministrator = await RoleManager.FindByNameAsync(Enum_UserType.Administrator.ToString());
                    //var administrator = roleAdministrator.Users.FirstOrDefault();

                    //var message = new MessageSendModel()
                    //{
                    //    UserFrom = administrator.UserId,
                    //    UserTo = user.Id,
                    //    Subject = HttpContext.ParseAndTranslate(string.Format("[[[Welcome to {0}!]]]", CacheHelper.Settings.Name)),
                    //    Body = HttpContext.ParseAndTranslate(string.Format("[[[Hi, Welcome to {0}! I am happy to assist you if you has any questions.]]]", CacheHelper.Settings.Name))

                    //};

                    //await MessageHelper.SendMessage(message);

                    //// Send an email with this link
                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

                    //var urlHelper = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext);
                    //var callbackUrl = urlHelper.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: System.Web.HttpContext.Current.Request.Url.Scheme);

                    //var emailTemplateQuery = await _emailTemplateService.Query(x => x.Slug.ToLower() == "signup").SelectAsync();
                    //var emailTemplate = emailTemplateQuery.FirstOrDefault();

                    //if (emailTemplate != null)
                    //{
                    //    dynamic email = new Postal.Email("Email");
                    //    email.To = user.Email;
                    //    email.From = CacheHelper.Settings.EmailAddress;
                    //    email.Subject = emailTemplate.Subject;
                    //    email.Body = emailTemplate.Body;
                    //    email.CallbackUrl = callbackUrl;
                    //    EmailHelper.SendEmail(email);
                    //}
                }

                string error = string.Empty;
                foreach (var item in result.Errors)
                {
                    error += $"{item} -  ";
                }

                return await CriaResposta(HttpStatusCode.InternalServerError, error);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Erro ao criar usuario.{e.Message}{e.InnerException.Message}");
            }
            
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            _servico.Delete(id);
            return CriaResposta(HttpStatusCode.OK,"Sucess Delete");

        }

        //[HttpGet]
        //[Route("ListGroupUser")]
        //public Task<HttpResponseMessage> ListGroupUser()
        //{            
        //    return CriaResposta(HttpStatusCode.OK, _servico.GetGroupUser());
        //}
    }
}
