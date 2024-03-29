﻿using System;
using System.Collections.Generic;
using Welic.Dominio;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;

using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Patterns.Repository.Pattern.Repositories;
using Welic.Dominio.Patterns.Service.Pattern;
using Welic.Dominio.Utilitarios.Entidades;

namespace Services.Users
{
    public class ServiceUser : Service<AspNetUser>, IServiceUser
    {
        public ServiceUser(IRepositoryAsync<AspNetUser> repository) : base(repository)
        {
        }

        //private readonly IRepositorioUser _repositorioUser;        

        //public ServiceUser(IUnidadeTrabalho unidadeTrabalho, IRepositorioUser repositorioUser) : base(unidadeTrabalho)
        //{            
        //    _repositorioUser = repositorioUser;            
        //}
        //public UserDto Save(UserDto userDto)
        //{
        //    var userMap = _repositorioUser.GetByEmail(userDto.Email);

        //    if (userMap != null)
        //    {                                
        //        userMap.Email = userDto.Email;
        //        userMap.ImagePerfil = userDto.ImagePerfil;
        //        userMap.EmailConfirmed = userDto.EmailConfirmed;
        //        userMap.NickName = userDto.NickName;                
        //        userMap.PhoneNumber = userDto.PhoneNumber;
        //        userMap.Id = userDto.Id;
        //        userMap.Guid = userDto.Guid;
        //        userMap.PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;
        //        userMap.LastAccessDate = DateTime.Now;
        //        userMap.Profession = userDto.Profession;
        //        userMap.FirstName = userDto.FirstName;
        //        userMap.Identity = userDto.Identity;
        //        userMap.LastName = userDto.LastName;
        //        userMap.ObjectState = ObjectState.Modified;
        //        userMap.Password = userDto.Password;
        //        userMap.RegisterDate = DateTime.Now;
        //        // userMap.GroupUserMap = new GroupUserMap(GroupUserEnum.None);//TODO: Implementar processo para salvar tipo de perfil
        //    }
        //    else
        //    {
        //        userMap = new AspNetUser
        //        {

        //            Email = userDto.Email,
        //            ImagePerfil = userDto.ImagePerfil,                    
        //            EmailConfirmed = userDto.EmailConfirmed,
        //            NickName = userDto.NickName,                    
        //            PhoneNumber = userDto.PhoneNumber,                   
        //            Id = Guid.NewGuid().ToString(),
        //            Guid = Guid.NewGuid(), 
        //            PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
        //            LastAccessDate = DateTime.Now,
        //            Profession = userDto.Profession,
        //            FirstName = userDto.FirstName,
        //            Identity = userDto.Identity,
        //            LastName = userDto.LastName,
        //            ObjectState = ObjectState.Added,
        //            Password = userDto.Password,
        //            RegisterDate = DateTime.Now,

        //        };
        //    }

        //    _repositorioUser.Save(userMap);            

        //    return GetById(userMap.Id);
        //}

        //public UserDto GetById(string id)
        //{
        //    return  AdapterUser.ConverterMapParaDto(_repositorioUser.GetById(id));
        //}

        //public List<UserDto> GetAll()
        //{
        //    return AdapterUser.ConverterMapParaDto(_repositorioUser.GetAll());
        //}

        //public void Delete(string id)
        //{
        //    if (id != null)
        //        return;
        //    _repositorioUser.Delete(id);
        //}

        //public UserDto GetByEmail(string email)
        //{
        //    return AdapterUser.ConverterMapParaDto(_repositorioUser.GetByEmail(email));
        //}

        //public UserDto GetByName(string name)
        //{
        //    return AdapterUser.ConverterMapParaDto(_repositorioUser.GetByName(name));
        //}

        //public AspNetUser Autenticar(AspNetUser comando)
        //{
        //    AspNetUser user = comando;
        //    return user.ValidarNomeUsuarioESenha(comando.NickName, comando.Password) ? user : null;
        //}

        //public IEnumerable<GroupUserDto> GetGroupUser()
        //{
        //    return AdapterUser.ConvertMapToDto(_repositorioUser.GetGroupUser());
        //}

    }
}
