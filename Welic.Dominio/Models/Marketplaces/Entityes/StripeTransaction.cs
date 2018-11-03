using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class StripeTransaction : Entity
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string ChargeID { get; set; }
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public bool IsCaptured { get; set; }
        public string FailureCode { get; set; }
        public string FailureMessage { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
    }
}
