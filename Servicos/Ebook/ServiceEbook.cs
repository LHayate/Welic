using System.Collections.Generic;
using System.Linq;
using Infra.Context;
using Welic.Dominio.Models.EBook.Map;
using Welic.Dominio.Models.EBook.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Ebook
{
    public class ServiceEbook: Service<EBookMap>, IServiceEBook
    {
        private AuthContext _context;
        public ServiceEbook(IRepositoryAsync<EBookMap> repository, AuthContext context) : base(repository)
        {
            _context = context;
        }

        public List<EBookMap> SearchBooks(string text)
        {
            return _context.EBook
                .Where(map => map.Title.Contains(text))
                .OrderBy(x => x.Title)
                .ToList();
        }
    }
}
