using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Registrators;
using Registrators.Helpers;
using Welic.Dominio.Enumerables;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Servicos;

using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;
using Welic.Dominio.ViewModels;
using Welic.WebSite.Models;
using Welic.WebSite.Utilities;

namespace Welic.WebSite.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : BaseController
    {
        public readonly IServiceUser _servico;
        private readonly IServicoMenu _servicoMenu;
        private IUnitOfWorkAsync _unitOfWorkAsync;

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

        public UserController(IServiceUser servico, IServicoMenu servicoMenu, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _servico = servico;
            _servicoMenu = servicoMenu;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        [HttpGet]
        [Route("getall")]
        public Task<HttpResponseMessage> GetAll()
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Query().Select(x=> x).ToList());
        }

        [HttpGet]
        [Route("getbyEmail/")]
        public Task<HttpResponseMessage> GetByEmail([FromUri]string email)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Query().Select(x=> x).FirstOrDefault(x=> x.Email == email));
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<HttpResponseMessage> GetById(string id)
        {
            return CriaResposta(HttpStatusCode.OK, _servico.Find(id));
        }


        [HttpPost]        
        [Route("Update")]
        public Task<HttpResponseMessage> Update([FromBody] AspNetUser aspNetUser)
        {
            try
            {
                _servico.Update(aspNetUser);
                _unitOfWorkAsync.SaveChanges();

                return CriaResposta(HttpStatusCode.OK, _servico.Query().Select(x => x).FirstOrDefault(x => x.Email == aspNetUser.Email &&
                                                                                                           x.NickName == aspNetUser.NickName &&
                                                                                                           x.Id == aspNetUser.Id
                ));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return CriaResposta(HttpStatusCode.InternalServerError,$"{e.Message} - {e.InnerException.Message}");
            }            
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Create")]
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
                    RegisterIP = HttpContext.Current.Request.GetVisitorIP(),
                    LastAccessDate = DateTime.Now,
                    LastAccessIP = HttpContext.Current.Request.GetVisitorIP(),
                    Guid = Guid.NewGuid(),
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Identity = model.Identity,
                    Profession = model.Profession,                    
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var menu = _servicoMenu.Query().Select(x => x).ToList();

                    _servicoMenu.SaveMenuUser(
                        new CommandMenu
                        {
                            MenuUser = menu,
                            NameUser = model.Email
                        }
                    );


                    switch (model.Profession)
                    {
                        case "Administrator":
                            RoleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.Administrator.ToString()));
                            UserManager.AddToRole(user.Id, Enum_UserType.Administrator.ToString());
                            break;
                        case "Teacher":
                            RoleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.Teacher.ToString()));
                            UserManager.AddToRole(user.Id, Enum_UserType.Teacher.ToString());
                            break;
                        case "Student":
                            RoleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.Student.ToString()));
                            UserManager.AddToRole(user.Id, Enum_UserType.Student.ToString());
                            break;
                        case "AllClass":
                            RoleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.AllClass.ToString()));
                            UserManager.AddToRole(user.Id, Enum_UserType.AllClass.ToString());
                            break;
                        default:
                            RoleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(Enum_UserType.Student.ToString()));
                            UserManager.AddToRole(user.Id, Enum_UserType.Student.ToString());
                            break;
                    }
                    
                    
                    return await CriaResposta(HttpStatusCode.OK, _servico.Query().Select(x=> x).FirstOrDefault(x=> x.Email == model.Email));
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
                    if(item.Contains("is already taken."))
                        return await CriaResposta(HttpStatusCode.Conflict, result.Errors);

                    if (item.ToLower().Contains("invalid"))
                        return await CriaResposta(HttpStatusCode.InternalServerError, item);


                    error += $"{item} -  ";
                }
                return await CriaResposta(HttpStatusCode.Unauthorized, error);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return await CriaResposta(HttpStatusCode.InternalServerError, e.Message);
            }
            

                              
        }

        //[HttpPost]
        //[Route("login")]        
        //public async Task<AspNetUser> Login(LoginViewModel model)
        //{            
        //    if (!ModelState.IsValid)
        //    {
        //        return null;
        //    }

        //    //Todo: Resolver Cache
        //    // Require the user to have a confirmed email before they can log on.
        //    //if (CacheHelper.Settings.EmailConfirmedRequired)
        //    //{
        //    var user = await UserManager.FindByNameAsync(model.Email);
        //    //if (user != null)
        //    //{
        //    //    var roleAdministrator = await RoleManager.FindByNameAsync(Enum_UserType.Administrator.ToString());
        //    //    var isAdministrator = user.Roles.Any(x => x.RoleId == roleAdministrator.Id);

        //    //    // Skip email check unless it's an administrator
        //    //    if (!isAdministrator && !await UserManager.IsEmailConfirmedAsync(user.Id))
        //    //    {
        //    //        ModelState.AddModelError("", "[[[You must have a confirmed email to log on.]]]");
        //    //        return View(model);
        //    //    }
        //    //}
        //    //}
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("", "Invalid login attempt.");               
        //    }

        //    // This doesn't count login failures towards account lockout
        //    // To enable password failures to trigger account lockout, change to shouldLockout: true
        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
                    
        //            return _servico.Query().Select(x=> x).FirstOrDefault(x=> x.Email == model.Email);               
        //        default:
        //            return null;
        //    }
        //}

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("delete/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            _servico.Delete(id);
            _unitOfWorkAsync.SaveChanges();
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
