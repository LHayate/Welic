using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.StoredProcedures;

namespace Infra.Context
{
    public partial class AuthContext : IStoredProcedures
    {
        public int UpdateCategoryItemsCount(int categoryID)
        {
            return Database.ExecuteSqlCommand("UPDATE CategoryStats SET COUNT = COUNT + 1 WHERE CategoryID = @p0", categoryID);
        }
    }
}
