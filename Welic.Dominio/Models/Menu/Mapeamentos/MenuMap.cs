using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio.Models.Menu.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Patterns.Pattern.Ef6;

namespace Welic.Dominio.Models.Menu.Mapeamentos
{
    public class MenuMap : Entity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string IconMenu { get; set; }

        public string Nivel { get;  set; }

        public string Action { get; set; }
        public string Controller { get; set; }
        public int? DadId { get; set; }
        //TODO: Criar Group de Acesso e Ordem
        //public int? GroupAcess { get; set; }
        public MenuMap Dad { get; private set; }

        private ICollection<AspNetUser> _usuarios;

        public ICollection<AspNetUser> Usuarios
        {
            get => _usuarios;

            private set => _usuarios = new List<AspNetUser>(value);
        }
        public MenuMap()
        {

        }
        public void AddUser(AspNetUser usuario)
        {
            if (Usuarios == null)
            {
                Usuarios = new List<AspNetUser>();
            }
            Usuarios.Add(usuario);
        }
    }
}
