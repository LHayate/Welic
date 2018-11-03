using System.Collections.Generic;
using PagedList;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.WebSite.Models.Grids;

namespace Welic.WebSite.Models
{
    public class SearchListingModel : SortViewModel
    {
        public int CategoryID { get; set; }

        public List<int> ListingTypeID { get; set; }

        public string SearchText { get; set; }

        public string Location { get; set; }

        public bool PhotoOnly { get; set; }

        public double? PriceFrom { get; set; }

        public double? PriceTo { get; set; }

        public List<MetaCategory> MetaCategories { get; set; }

        public List<ListingItemModel> Listings { get; set; }

        public IPagedList<ListingItemModel> ListingsPageList { get; set; }

        public List<Category> Categories { get; set; }

        public List<Category> BreadCrumb { get; set; }

        public List<ListingType> ListingTypes { get; set; }

        public ListingModelGrid Grid { get; set; }
    }
}