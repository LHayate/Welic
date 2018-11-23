
namespace Welic.Dominio.Core.Controllers

{
    public interface IPaymentController
    {
        bool OrderAction(int id, int status, out string message);

        bool HasPaymentMethod(string userId);

        int GetTransactionCount();
    }
}
