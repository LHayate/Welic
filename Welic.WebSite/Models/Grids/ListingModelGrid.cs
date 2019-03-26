using System.Linq;
using GridMvc;

namespace WebApi.Models.Grids
{
    public class ListingModelGrid : Grid<ListingItemModel>
    {
        public ListingModelGrid(IQueryable<ListingItemModel> items)
            : base(items)
        {
        }
    }
}