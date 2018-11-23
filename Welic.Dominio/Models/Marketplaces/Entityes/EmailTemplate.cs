using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class EmailTemplate : Entity
    {
        public int ID { get; set; }
        public string Slug { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool SendCopy { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
    }
}
