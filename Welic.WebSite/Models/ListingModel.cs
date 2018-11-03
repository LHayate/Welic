using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.WebSite.Models.Grids;

namespace Welic.WebSite.Models
{
    public class ListingModel
    {
        public ListingsGrid Grid { get; set; }

        public List<ListingItemModel> Listings { get; set; }

        public List<Category> Categories { get; set; }
    }
}