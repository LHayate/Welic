using System;
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
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;

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

        public List<MenuDto> GetMenuByUser(string email)
        {
            var usuario = _repositorioUser.GetByEmail(email);

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

        public List<MenuDto> GetMenuByUserId(string id)
        {
            var usuario = _repositorioUser.GetById(id);

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
            //TODO: Corrigir para Email
            var usuario = _repositorioUser.GetByEmail(menuUser.NameUser);

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

        public void SaveMenu(MenuDto menuDto)
        {
            var found = _repositorioMenu.GetById(menuDto.Id);

            if (found != null)
            {                
                found.Id = menuDto.Id;
                found.Title = menuDto.Title;
                found.IconMenu = menuDto.IconMenu;
                found.Nivel = menuDto.Nivel;
                found.DadId = menuDto.MenuDadId;
                found.Action = menuDto.Action;
                found.Controller = menuDto.Controller;
                found.ObjectState = ObjectState.Modified;
            }
            else
            {
                found = new MenuMap
                {
                    Id = menuDto.Id,
                    Title = menuDto.Title,
                    IconMenu = menuDto.IconMenu,
                    Nivel = menuDto.Nivel,
                    DadId = menuDto.MenuDadId,
                    Action = menuDto.Action,
                    Controller = menuDto.Controller,
                    ObjectState = ObjectState.Added                    
                };
            }

            _repositorioMenu.Save(found);
        }

        public MenuDto GetbyId(int id)
        {
            return AdapterMenu.ConverterMapParaDto(_repositorioMenu.GetById(id));
        }
    }
}
