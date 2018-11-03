using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Marketplaces.Services
{
    public interface IListingService : IService<Listing>
    {
        Dictionary<DateTime, int> GetItemsCount(DateTime datetime);

        Dictionary<Category, int> GetCategoryCount();
    }
}
