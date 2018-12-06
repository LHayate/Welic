using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.ConfigApp.Map
{
    public class ConfigAppMap: Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool Biometria { get; set; }
        public AspNetUser AspNetUser { get; set; }

    }
}
