using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Uploads.Maps
{
    public class UploadsMap : Entity
    {
        public Guid UploadId { get; set; }
        public string Path { get; set; }

        public string UserId { get; set; }
        public AspNetUser User { get; set; }
    }
}
