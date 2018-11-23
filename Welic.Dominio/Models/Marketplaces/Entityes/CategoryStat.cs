using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Marketplaces.Entityes
{
    public partial class CategoryStat : Entity
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int Count { get; set; }
        public virtual Category Category { get; set; }
    }
}
