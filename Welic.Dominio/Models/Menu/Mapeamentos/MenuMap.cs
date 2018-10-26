using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Menu.Mapeamentos
{
    public class MenuMap
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }

        public string Nivel { get;  set; }

        public string Action { get; set; }
        public string Controller { get; set; }
        public int? DadId { get; set; }
        public MenuMap Dad { get; private set; }

        private ICollection<UserMap> _usuarios;

        public ICollection<UserMap> Usuarios
        {
            get => _usuarios;

            private set => _usuarios = new List<UserMap>(value);
        }
        public MenuMap()
        {

        }
        public void AddUser(UserMap usuario)
        {
            if (Usuarios == null)
            {
                Usuarios = new List<UserMap>();
            }
            Usuarios.Add(usuario);
        }
    }
}
