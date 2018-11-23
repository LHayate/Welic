using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Users.Mapeamentos
{
    public partial class AspNetRole : Entity
    {
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
