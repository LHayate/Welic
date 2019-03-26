using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace WebApi.Models
{
    public class MetaFieldModel
    {
        public MetaField MetaField { get; set; }

        public List<Category> Categories { get; set; }
    }
}
