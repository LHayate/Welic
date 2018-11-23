using Welic.Infra.StoredProcedures;

namespace Servicos.MarketPlace
{
    public class SqlDbService
    {        
        private readonly IStoredProcedures _storedProcedures;

        public SqlDbService(IStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

        public int UpdateCategoryItemCount(int categoryID)
        {
            return _storedProcedures.UpdateCategoryItemsCount(categoryID);
        }
    }
}
