using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public class Category : Entity
    {
        public Category()
        {
            this.CategoryListingTypes = new List<CategoryListingType>();
            this.CategoryStats = new List<CategoryStat>();
            this.Listings = new List<Listing>();
            this.MetaCategories = new List<MetaCategory>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public bool Enabled { get; set; }
        public int Ordering { get; set; }
        public virtual ICollection<CategoryListingType> CategoryListingTypes { get; set; }
        public virtual ICollection<CategoryStat> CategoryStats { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<MetaCategory> MetaCategories { get; set; }
    }
}
