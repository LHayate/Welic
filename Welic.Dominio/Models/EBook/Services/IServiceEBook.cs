using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.EBook.Services
{
    public interface IServiceEBook: IService<EBookMap>
    {
        List<EBookMap> SearchBooks(string text);
    }
}
