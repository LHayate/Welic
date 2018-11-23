using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Marketplaces.Entityes;
using Welic.Dominio.Models.Uploads.Maps;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Welic.Dominio.Models.Uploads.Services
{
    public interface IUploadsService : IService<UploadsMap>
    {
        //bool SavePath(string path);
    }
}
