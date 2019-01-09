using Registrators.HookServices;
using Registrators.Plugins;
using Servicos;
using Servicos.Acesso;
using Servicos.City;
using Servicos.Cursos;
using Servicos.Departamento;
using Servicos.Ebook;
using Servicos.Empresa;
using Servicos.Estacionamento;
using Servicos.Live;
using Servicos.MarketPlace;
using Servicos.Menu;
using Servicos.News;
using Servicos.Pessoa;
using Servicos.Schedule;
using Servicos.Seguranca;
using Servicos.Uploads;
using Servicos.Users;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;
using Welic.Dominio;
using Welic.Dominio.Eventos;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Dominio.Models.Acesso.Servicos;
using Welic.Dominio.Models.City.Map;
using Welic.Dominio.Models.City.Service;
using Welic.Dominio.Models.Client.Map;
using Welic.Dominio.Models.Client.Service;
using Welic.Dominio.Models.Curso.Map;
using Welic.Dominio.Models.Curso.Service;
using Welic.Dominio.Models.Departamento.Map;
using Welic.Dominio.Models.Departamento.Service;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.EBook.Services;
using Welic.Dominio.Models.Empresa.Map;
using Welic.Dominio.Models.Empresa.Service;
using Welic.Dominio.Models.Estacionamento.Map;
using Welic.Dominio.Models.Estacionamento.Services;
using Welic.Dominio.Models.Lives.Maps;
using Welic.Dominio.Models.Lives.Repositoryes;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Menu.Repositorios;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.News.Maps;
using Welic.Dominio.Models.News.Services;
using Welic.Dominio.Models.Schedule.Maps;
using Welic.Dominio.Models.Schedule.Services;
using Welic.Dominio.Models.Segurança.Map;
using Welic.Dominio.Models.Segurança.Service;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Uploads.Services;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Servicos;

using Welic.Dominio.Patterns.Pattern.Ef6;
using Welic.Dominio.Patterns.Repository.Pattern.DataContext;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;
using Welic.Infra;
using Welic.Infra.Context;
using Welic.Infra.StoredProcedures;
using Welic.Repositorios.Dispositives;
using Welic.Repositorios.Live;
using Welic.Repositorios.Menu;



namespace Registrators
{
    public class Registrator
    {
        public static void  Register(IUnityContainer container)
        {
            container
                .RegisterType<IDataContextAsync, AuthContext>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())

                .RegisterType<IRepositoryAsync<Category>, Repository<Category>>()
                .RegisterType<IRepositoryAsync<Listing>, Repository<Listing>>()
                .RegisterType<IRepositoryAsync<ListingPicture>, Repository<ListingPicture>>()
                .RegisterType<IRepositoryAsync<Picture>, Repository<Picture>>()
                .RegisterType<IRepositoryAsync<Order>, Repository<Order>>()
                .RegisterType<IRepositoryAsync<StripeConnect>, Repository<StripeConnect>>()
                .RegisterType<IRepositoryAsync<MetaField>, Repository<MetaField>>()
                .RegisterType<IRepositoryAsync<MetaCategory>, Repository<MetaCategory>>()
                .RegisterType<IRepositoryAsync<ListingMeta>, Repository<ListingMeta>>()
                .RegisterType<IRepositoryAsync<ContentPage>, Repository<ContentPage>>()
                .RegisterType<IRepositoryAsync<SettingDictionary>, Repository<SettingDictionary>>()
                .RegisterType<IRepositoryAsync<ListingStat>, Repository<ListingStat>>()
                .RegisterType<IRepositoryAsync<ListingReview>, Repository<ListingReview>>()
                .RegisterType<IRepositoryAsync<EmailTemplate>, Repository<EmailTemplate>>()
                .RegisterType<IRepositoryAsync<CategoryStat>, Repository<CategoryStat>>()
                .RegisterType<IRepositoryAsync<AspNetUser>, Repository<AspNetUser>>()
                .RegisterType<IRepositoryAsync<AspNetRole>, Repository<AspNetRole>>()
                .RegisterType<IRepositoryAsync<ListingType>, Repository<ListingType>>()
                .RegisterType<IRepositoryAsync<CategoryListingType>, Repository<CategoryListingType>>()
                .RegisterType<IRepositoryAsync<Message>, Repository<Message>>()
                .RegisterType<IRepositoryAsync<MessageParticipant>, Repository<MessageParticipant>>()
                .RegisterType<IRepositoryAsync<MessageReadState>, Repository<MessageReadState>>()
                .RegisterType<IRepositoryAsync<MessageThread>, Repository<MessageThread>>()
                .RegisterType<IRepositoryAsync<UploadsMap>, Repository<UploadsMap>>()
                .RegisterType<IRepositoryAsync<CursoMap>,Repository<CursoMap>>()
                .RegisterType<IRepositoryAsync<LiveMap>,Repository<LiveMap>>()
                .RegisterType<IRepositoryAsync<EBookMap>, Repository<EBookMap>>()
                .RegisterType<IRepositoryAsync<NewsMap>, Repository<NewsMap>>()
                .RegisterType<IRepositoryAsync<ScheduleMap>,Repository<ScheduleMap>>()
                .RegisterType<IRepositoryAsync<MenuMap>,Repository<MenuMap>>()
                .RegisterType<IRepositoryAsync<CityMap>,Repository<CityMap>>()
                .RegisterType<IRepositoryAsync<PessoaMap>,Repository<PessoaMap>>()
                .RegisterType<IRepositoryAsync<DepartamentoMap>,Repository<DepartamentoMap>>()
                .RegisterType<IRepositoryAsync<PermissionMap>,Repository<PermissionMap>>()
                .RegisterType<IRepositoryAsync<EstacionamentoMap>,Repository<EstacionamentoMap>>()
                .RegisterType<IRepositoryAsync<EstacionamentoVagasMap>,Repository<EstacionamentoVagasMap>>()
                .RegisterType<IRepositoryAsync<EmpresaMap>,Repository<EmpresaMap>>()
                .RegisterType<IRepositoryAsync<SolicitacoesVagasMap>,Repository<SolicitacoesVagasMap>>()
                .RegisterType<IRepositoryAsync<VeiculosMap>,Repository<VeiculosMap>>()
                .RegisterType<IRepositoryAsync<ProgransMap>,Repository<ProgransMap>>()
                

                .RegisterType<IServiceProgram, ServiceProgram>()
                .RegisterType<IServiceVeiculo, ServiceVeiculo>()
                .RegisterType<IServiceSolicitacoesVagas, ServiceSolicitacoesVagas>()
                .RegisterType<IServiceEmpresa, ServiceEmpresa>()
                .RegisterType<IServiceEstacionamentoVagas, ServiceEstacionamentoVagas>()
                .RegisterType<IServiceEstacionamento, ServiceEstacionamento>()
                .RegisterType<IServicePermission, ServicePermission>()
                .RegisterType<IServiceDepartamento, ServiceDepartamento>()
                .RegisterType<IServicePessoa, ServicePessoa>()
                .RegisterType<IServiceCity, ServiceCity>()
                .RegisterType<IServiceUser, ServiceUser>()
                .RegisterType<IServiceSchedule, ServiceSchedule>()
                .RegisterType<IServiceNews, ServiceNews>()
                .RegisterType<IServiceEBook, ServiceEbook>()
                .RegisterType<IServiceLive, ServiceLive>()
                .RegisterType<ICategoryService, CategoryService>()
                .RegisterType<ICategoryStatService, CategoryStatService>()
                .RegisterType<IListingService, ListingService>()
                .RegisterType<IListingPictureService, ListingPictureService>()
                .RegisterType<IPictureService, PictureService>()
                .RegisterType<IOrderService, OrderService>()
                .RegisterType<ICustomFieldService, CustomFieldService>()
                .RegisterType<ICustomFieldCategoryService, CustomFieldCategoryService>()
                .RegisterType<ICustomFieldListingService, CustomFieldListingService>()
                .RegisterType<IContentPageService, ContentPageService>()
                .RegisterType<ISettingDictionaryService, SettingDictionaryService>()
                .RegisterType<IListingStatService, ListingStatService>()
                .RegisterType<IEmailTemplateService, EmailTemplateService>()
                .RegisterType<IAspNetUserService, AspNetUserService>()
                .RegisterType<IAspNetRoleService, AspNetRoleService>()
                .RegisterType<IListingTypeService, ListingTypeService>()
                .RegisterType<IListingReviewService, ListingReviewService>()
                .RegisterType<ICategoryListingTypeService, CategoryListingTypeService>()
                .RegisterType<IMessageService, MessageService>()
                .RegisterType<IMessageParticipantService, MessageParticipantService>()
                .RegisterType<IMessageReadStateService, MessageReadStateService>()
                .RegisterType<IMessageThreadService, MessageThreadService>()
                .RegisterType<IStoredProcedures, AuthContext>(new PerRequestLifetimeManager())
                .RegisterType<SqlDbService, SqlDbService>()
                .RegisterType<IUploadsService, UploadsService>()
                .RegisterType<ICursoService, CursoService>()
                ;

            container
                .RegisterType<IHookService, HookService>()
                .RegisterType<IPluginFinder, PluginFinder>();

            
            RegistrarUnidadeDeTrabalho(container);
            RegistrarServico(container);
            RegistrarNotificacaoDominio(container);     
            RegisterDispositivos(container);
            RegisterLive(container);          
            RegisterMenu(container);
            RegisterSetting(container);
            RegisterDataCacheService(container);

        }
        private static void RegisterDataCacheService(IUnityContainer container)
        {
            container.RegisterType<DataCacheService, DataCacheService>(new ContainerControlledLifetimeManager());
        }
        private static void RegisterSetting(IUnityContainer container)
        {
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<IRepositoryAsync<Setting>, Repository<Setting>>();
        }
        private static void RegisterMenu(IUnityContainer container)
        {
            container.RegisterType<IServicoMenu, ServicoMenu>();
            container.RegisterType<IRepositorioMenu, RepositorioMenu>();           
        }
                  
        private static void RegistrarUnidadeDeTrabalho(IUnityContainer container)
        {
            container.RegisterType<IUnidadeTrabalho, UnidadeTrabalho>();
        }
        private static void RegistrarServico(IUnityContainer container)
        {
            container.RegisterType<IServico, Servico>();
        }
        private static void RegistrarNotificacaoDominio(IUnityContainer container)
        {
            container.RegisterType<IManipulador<NotificacaoDominio>, ManipuladorNotificacaoDominio>(
                new HierarchicalLifetimeManager());
        }

        private static void RegisterDispositivos(IUnityContainer container)
        {
            container.RegisterType<IRepositorioDispositivos, RepositoryDispositivos>();
            container.RegisterType<IServicoDispositivo, ServicoDispositivo>();
        }
        private static void RegisterLive(IUnityContainer container)
        {
            container.RegisterType<IRepositoryLive, RepositoryLive>();
        }
    }
}
