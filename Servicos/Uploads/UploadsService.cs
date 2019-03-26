using Infra.Context;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Uploads.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Uploads
{
    public class UploadsService : Service<UploadsMap>, IUploadsService
    {
        private AuthContext _context;
        public UploadsService(IRepositoryAsync<UploadsMap> repository, AuthContext context) : base(repository)
        {
            _context = context;
        }

        
    }
}
