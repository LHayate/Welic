using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            CategoryListingTypeID = new List<int>();
        }

        public Category Category { get; set; }

        public List<ListingType> ListingTypes { get; set; }

        public List<int> CategoryListingTypeID { get; set; }
    }
}