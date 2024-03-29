﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Welic.Dominio;
using Welic.Dominio.Models.Menu.Adapter;
using Welic.Dominio.Models.Menu.Command;
using Welic.Dominio.Models.Menu.Dtos;
using Welic.Dominio.Models.Menu.Mapeamentos;
using Welic.Dominio.Models.Menu.Repositorios;
using Welic.Dominio.Models.Menu.Servicos;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;

namespace Services.Menu
{
    public class ServicoMenu : Service<MenuMap>, IServicoMenu
    {
        private readonly IRepositorioMenu _repositorioMenu;
        private IServiceUser _serviceUser;
        public ServicoMenu(IRepositoryAsync<MenuMap> repository, IServiceUser serviceUser, IRepositorioMenu repositorioMenu ) : base(repository)
        {
            _serviceUser = serviceUser;
            _repositorioMenu = repositorioMenu;
        }

        public  void SaveMenuUser(CommandMenu menuUser)
        {
            //TODO: Corrigir para Email
            var usuario =   _serviceUser.Query().Select(x => x).FirstOrDefault(x => x.Email == menuUser.NameUser);
         

            if (menuUser.MenuUser?.Count > 0)
            {               
                _repositorioMenu.SaveMenuUser(usuario.Id, this.Query().Select(m => m).ToList());
            }            
        }


        
        //private readonly IRepositorioUser _repositorioUser;

        //public ServicoMenu(IUnidadeTrabalho unidadeTrabalho, 
        //    
        //    IRepositorioUser repositorioUser) 
        //    : base(unidadeTrabalho)
        //{
        //    
        //    _repositorioUser = repositorioUser;
        //}        

        //public List<MenuDto> GetMenuComplet()
        //{
        //    List<MenuMap> listaMenu = _repositorioMenu.GetAllMenu();

        //    if (listaMenu.Count == 0)
        //    {
        //        Rollback("Menu de acesso não encontrado.");
        //        return null;
        //    }

        //    List<MenuDto> menuCompleto = listaMenu.Select(MenuDto.Map()).ToList();

        //    return menuCompleto;
        //}

        public List<MenuDto> GetMenuByUser(string email)
        {
            var usuario = _serviceUser.Query().Select().FirstOrDefault(x=> x.Email == email);

            List<MenuMap> listaMenu = _repositorioMenu.GetbyIdUser(usuario.Id);
           
            return AdapterMenu.ConverterMapParaDto(listaMenu);
        }

        public List<MenuDto> GetMenuByUserId(string id)
        {
            var usuario = _serviceUser.Find(id);          

            List<MenuMap> listaMenu = _repositorioMenu.GetbyIdUser(usuario.Id);            

            return AdapterMenu.ConverterMapParaDto(listaMenu);
        }



        //public void SaveMenu(MenuDto menuDto)
        //{
        //    var found = _repositorioMenu.GetById(menuDto.Id);

        //    if (found != null)
        //    {                
        //        found.Id = menuDto.Id;
        //        found.Title = menuDto.Title;
        //        found.IconMenu = menuDto.IconMenu;
        //        found.Nivel = menuDto.Nivel;
        //        found.DadId = menuDto.MenuDadId;
        //        found.Action = menuDto.Action;
        //        found.Controller = menuDto.Controller;
        //        found.ObjectState = ObjectState.Modified;
        //        //found.GroupAcess = menuDto.GroupAcess;
        //    }
        //    else
        //    {
        //        found = new MenuMap
        //        {
        //            Id = menuDto.Id,
        //            Title = menuDto.Title,
        //            IconMenu = menuDto.IconMenu,
        //            Nivel = menuDto.Nivel,
        //            DadId = menuDto.MenuDadId,
        //            Action = menuDto.Action,
        //            Controller = menuDto.Controller,
        //            ObjectState = ObjectState.Added ,
        //            //GroupAcess =  menuDto.GroupAcess
        //        };
        //    }

        //    _repositorioMenu.Save(found);
        //}

        //public MenuDto GetbyId(int id)
        //{
        //    return AdapterMenu.ConverterMapParaDto(_repositorioMenu.GetById(id));
        //}

    }
}
