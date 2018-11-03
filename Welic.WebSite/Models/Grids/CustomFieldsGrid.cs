using System.Linq;
using GridMvc;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Models.Grids
{
    public class CustomFieldsGrid : Grid<MetaField>
    {
        public CustomFieldsGrid(IQueryable<MetaField> items)
            : base(items)
        {
        }
    }
}