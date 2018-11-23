using System.Linq;
using GridMvc;
using Welic.Dominio.Models.Marketplaces.Entityes;

namespace Welic.WebSite.Models.Grids
{
    public class OrdersGrid : Grid<Order>
    {
        public OrdersGrid(IQueryable<Order> items)
            : base(items)
        {
        }
    }
}