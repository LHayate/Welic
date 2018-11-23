using System.Collections.Generic;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.WebSite.Extensions;

namespace Welic.WebSite.Models
{
    public class NavigationSideModel
    {
        public IEnumerable<TreeItem<Category>> CategoryTree { get; set; }

        public IEnumerable<ContentPage> ContentPages { get; set; }
    }
}
