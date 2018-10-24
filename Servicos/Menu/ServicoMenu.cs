using System.Collections.Generic;
using System.Linq;
using Welic.Dominio;
using Welic.Dominio.Models.Menu.Adapter;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Menu.Repositorios;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Repositorios;

namespace Servicos.Menu
{
    public class ServicoMenu : Servico, IServicoMenu
    {
        private readonly IRepositorioMenu _repositorioMenu;
        private readonly IRepositorioUser _repositorioUser;

        public ServicoMenu(IUnidadeTrabalho unidadeTrabalho, 
            IRepositorioMenu repositorioMenu, 
            IRepositorioUser repositorioUser) 
            : base(unidadeTrabalho)
        {
            _repositorioMenu = repositorioMenu;
            _repositorioUser = repositorioUser;
        }        

        public List<MenuDto> GetMenuComplet()
        {
            List<MenuMap> listaMenu = _repositorioMenu.GetAllMenu();

            if (listaMenu.Count == 0)
            {
                Rollback("Menu de acesso não encontrado.");
                return null;
            }

            List<MenuDto> menuCompleto = listaMenu.Select(MenuDto.Map()).ToList();

            return menuCompleto;
        }

        public List<MenuDto> GetMenuByUser(string nomeUsuario)
        {
            var usuario = _repositorioUser.GetByName(nomeUsuario);

            if (usuario == null)
            {
                Rollback("Usuário não identificado.");
                return null;
            }

            List<MenuMap> listaMenu = _repositorioMenu.GetbyIdUser(usuario.Id);

            if (listaMenu.Count == 0)
            {
                Rollback("Menu de acesso não encontrado.");
                return null;
            }

            return AdapterMenu.ConverterMapParaDto(listaMenu);
        }

        public void SaveMenuUser(CommandMenu menuUser)
        {
            var usuario = _repositorioUser.GetByName(menuUser.NameUser);

            if (usuario == null)
            {
                Rollback("Usuário não identificado.");
                return;
            }

            if (menuUser.MenuUser?.Count > 0)
            {
                var novoMenuDoUsuario =
                    _repositorioMenu.GetListbyIdByList(menuUser.MenuUser.Select(m => m.Id).ToList());
                _repositorioMenu.SaveMenuUser(usuario.Id, novoMenuDoUsuario);
            }

            Commit();
        }
    }
}
