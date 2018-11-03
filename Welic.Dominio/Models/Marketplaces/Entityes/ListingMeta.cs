using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class ListingMeta : Entity
    {
        public int ID { get; set; }
        public int ListingID { get; set; }
        public int FieldID { get; set; }
        public string Value { get; set; }
        public virtual Listing Listing { get; set; }
        public virtual MetaField MetaField { get; set; }
    }
}
