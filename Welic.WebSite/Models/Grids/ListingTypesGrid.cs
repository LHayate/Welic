using System.Linq;
using GridMvc;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models.Grids
{
    public class ListingTypesGrid : Grid<ListingType>
    {
        public ListingTypesGrid(IQueryable<ListingType> ListingTypes)
            : base(ListingTypes)
        {
        }
    }
}