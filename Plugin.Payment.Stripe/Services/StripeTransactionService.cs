using Plugin.Payment.Stripe.Data;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Plugin.Payment.Services
{
    public interface IStripeTransactionService : IService<StripeTransaction>
    {
    }

    public class StripeTransactionService : Service<StripeTransaction>, IStripeTransactionService
    {
        public StripeTransactionService(IRepositoryAsync<StripeTransaction> repository)
            : base(repository)
        {
        }
    }
}
