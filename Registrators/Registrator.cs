using Servicos;
using Servicos.Acesso;
using Servicos.Live;
using Servicos.News;
using Servicos.Schedule;
using Servicos.Users;
using Unity;
using Unity.Lifetime;
using Welic.Dominio;
using Welic.Dominio.Eventos;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Dominio.Models.Acesso.Servicos;
using Welic.Dominio.Models.Lives.Repositoryes;
using Welic.Dominio.Models.Lives.Services;
using Welic.Dominio.Models.News.Repositoryes;
using Welic.Dominio.Models.News.Services;
using Welic.Dominio.Models.Schedule.Repositoryes;
using Welic.Dominio.Models.Schedule.Services;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Infra;
using Welic.Repositorios.Dispositives;
using Welic.Repositorios.Live;
using Welic.Repositorios.News;
using Welic.Repositorios.Schedule;
using Welic.Repositorios.Users;

namespace Registrators
{
    public class Registrator
    {
        public static void  Register(UnityContainer container)
        {
            RegisterUser(container);
            RegistrarUnidadeDeTrabalho(container);
            RegistrarServico(container);
            RegistrarNotificacaoDominio(container);     
            RegisterDispositivos(container);
            RegisterLive(container);
            RegisterSchedule(container);
            RegisterNews(container);
        }

        private static void RegisterNews(UnityContainer container)
        {
            container.RegisterType<IServiceNews, ServiceNews>();
            container.RegisterType<IRepositoryNews, RepositoryNews>();
        }
        private static void RegisterSchedule(UnityContainer container)
        {
            container.RegisterType<IServiceSchedule, ServiceSchedule>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositorySchedule, RepositorySchedule>();
        }

        private static void RegisterUser(UnityContainer conteiner)
        {
            conteiner.RegisterType<IServiceUser, ServiceUser>(new HierarchicalLifetimeManager());
            conteiner.RegisterType<IRepositorioUser, RepositoryUser>(new HierarchicalLifetimeManager());
        }
        private static void RegistrarUnidadeDeTrabalho(UnityContainer container)
        {
            container.RegisterType<IUnidadeTrabalho, UnidadeTrabalho>(new HierarchicalLifetimeManager());
        }
        private static void RegistrarServico(UnityContainer container)
        {
            container.RegisterType<IServico, Servico>(new HierarchicalLifetimeManager());
        }
        private static void RegistrarNotificacaoDominio(UnityContainer container)
        {
            container.RegisterType<IManipulador<NotificacaoDominio>, ManipuladorNotificacaoDominio>(
                new HierarchicalLifetimeManager());
        }

        private static void RegisterDispositivos(UnityContainer container)
        {
            container.RegisterType<IRepositorioDispositivos, RepositoryDispositivos>();
            container.RegisterType<IServicoDispositivo, ServicoDispositivo>();
        }
        private static void RegisterLive(UnityContainer container)
        {
            container.RegisterType<IRepositoryLive, RepositoryLive>();
            container.RegisterType<IServiceLive, ServiceLive>();
        }
    }
}
