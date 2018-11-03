using System.Linq;
using GridMvc;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Models.Grids
{
    public class ListingsGrid : Grid<Listing>
    {
        public ListingsGrid(IQueryable<Listing> items)
            : base(items)
        {
        }
    }
}