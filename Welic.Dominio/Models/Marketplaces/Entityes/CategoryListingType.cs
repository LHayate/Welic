using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class CategoryListingType : Entity
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int ListingTypeID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ListingType ListingType { get; set; }
    }
}
