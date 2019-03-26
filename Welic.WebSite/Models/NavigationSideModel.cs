using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;
using WebApi.Extensions;

namespace WebApi.Models
{
    public class NavigationSideModel
    {
        public IEnumerable<TreeItem<Category>> CategoryTree { get; set; }

        public IEnumerable<ContentPage> ContentPages { get; set; }
    }
}
