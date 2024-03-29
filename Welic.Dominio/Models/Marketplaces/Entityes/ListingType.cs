﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class ListingType : Entity
    {
        public ListingType()
        {
            this.CategoryListingTypes = new List<CategoryListingType>();
            this.Listings = new List<Listing>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string ButtonLabel { get; set; }
        public bool PriceEnabled { get; set; }
        public string PriceUnitLabel { get; set; }
        public int OrderTypeID { get; set; }
        public string OrderTypeLabel { get; set; }
        public bool PaymentEnabled { get; set; }
        public bool ShippingEnabled { get; set; }
        public virtual ICollection<CategoryListingType> CategoryListingTypes { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
