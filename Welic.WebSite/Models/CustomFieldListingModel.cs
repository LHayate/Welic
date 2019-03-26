using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models
{
    public class CustomFieldListingModel
    {
        public List<MetaCategory> MetaCategories { get; set; }

        public int ListingID { get; set; }
    }
}
