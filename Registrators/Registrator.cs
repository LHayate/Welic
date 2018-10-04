using Registrators;
using Servicos;
using Servicos.Acesso;
using Servicos.Users;
using Unity;
using Unity.Lifetime;
using Welic.Dominio;
using Welic.Dominio.Eventos;
using Welic.Dominio.Models.Acesso.Repositorios;
using Welic.Dominio.Models.Acesso.Servicos;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Infra;
using Welic.Repositorios.Dispositives;
using Welic.Repositorios.Users;

namespace Welic.Registrators
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
    }
}
