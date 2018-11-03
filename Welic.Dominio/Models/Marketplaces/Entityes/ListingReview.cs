using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class ListingReview : Entity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public Nullable<int> ListingID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string UserFrom { get; set; }
        public string UserTo { get; set; }
        public bool Active { get; set; }
        public bool Enabled { get; set; }
        public bool Spam { get; set; }
        public System.DateTime Created { get; set; }
        public virtual AspNetUser AspNetUserFrom { get; set; }
        public virtual AspNetUser AspNetUserTo { get; set; }
        public virtual Listing Listing { get; set; }
        public virtual Order Order { get; set; }
    }
}
