using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Lives.Maps
{
    public class FavoriteLiveMap: Entity
    {
        public int IdFavorite { get; set; }
        public string IdUser { get; set; }
        public int IdLive { get; set; }


        public AspNetUser AspNetUser { get; set; }
        public LiveMap LiveMap { get; set; }
    }
}
