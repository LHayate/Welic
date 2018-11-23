using System.Linq;
using GridMvc;

namespace Welic.WebSite.Models.Grids
{
    public class ListingModelGrid : Grid<ListingItemModel>
    {
        public ListingModelGrid(IQueryable<ListingItemModel> items)
            : base(items)
        {
        }
    }
}