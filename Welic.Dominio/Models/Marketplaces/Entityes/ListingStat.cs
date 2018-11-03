using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class ListingStat : Entity
    {
        public int ID { get; set; }
        public int CountView { get; set; }
        public int CountSpam { get; set; }
        public int CountRepeated { get; set; }
        public int ListingID { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
