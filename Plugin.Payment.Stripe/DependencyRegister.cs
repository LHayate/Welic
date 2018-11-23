using Plugin.Payment.Stripe.Data;
using Plugin.Payment.Services;
using Registrators.Plugins;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Welic.Dominio.Patterns.Pattern.Ef6;
using Welic.Dominio.Patterns.Repository.Pattern.DataContext;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Repository.Pattern.UnitOfWork;

namespace Plugin.Payment.Stripe
{
    public class DependencyRegister : IDependencyRegister
    {
        public void Register(IUnityContainer container)
        {
        //http://stackoverflow.com/questions/4059991/microsoft-unity-how-to-specify-a-certain-parameter-in-constructor

            container.RegisterType<IDataContextAsync, StripeContext>("dataContextStripe",
                new PerRequestLifetimeManager());

            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>("unitOfWorkStripe",
                new PerRequestLifetimeManager(),
                new InjectionConstructor(
                    new ResolvedParameter<IDataContextAsync>("dataContextStripe")
                ));

            container.RegisterType<IRepositoryAsync<StripeConnect>, Repository<StripeConnect>>(
                new InjectionConstructor(
                    new ResolvedParameter<IDataContextAsync>("dataContextStripe"),
                    new ResolvedParameter<IUnitOfWorkAsync>("unitOfWorkStripe")
                ));

            container.RegisterType<IRepositoryAsync<StripeTransaction>, Repository<StripeTransaction>>(
                new InjectionConstructor(
                    new ResolvedParameter<IDataContextAsync>("dataContextStripe"),
                    new ResolvedParameter<IUnitOfWorkAsync>("unitOfWorkStripe")
                ));

            container.RegisterType<IStripeConnectService, StripeConnectService>();
            container.RegisterType<IStripeTransactionService, StripeTransactionService>();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
