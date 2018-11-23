using Plugin.Payment.Stripe.Data;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Plugin.Payment.Services
{
    public interface IStripeConnectService : IService<StripeConnect>
    {
    }

    public class StripeConnectService : Service<StripeConnect>, IStripeConnectService
    {
        public StripeConnectService(IRepositoryAsync<StripeConnect> repository)
            : base(repository)
        {
        }
    }
}
