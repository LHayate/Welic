using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Marketplaces.Services;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Models.Uploads.Services;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;
using Welic.Infra.Context;

namespace Servicos.Uploads
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
