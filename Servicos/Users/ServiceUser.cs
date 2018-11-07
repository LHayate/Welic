using System;
using System.Collections.Generic;
using Welic.Dominio;
using Welic.Dominio.Models.Users.Adapters;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Dominio.Models.Users.Servicos;
using Welic.Dominio.Patterns.Repository.Pattern.Infrastructure;
using Welic.Dominio.Utilitarios.Entidades;

namespace Servicos.Users
{
    public class ServiceUser : Servico, IServiceUser
    {
        private readonly IRepositorioUser _repositorioUser;        

        public ServiceUser(IUnidadeTrabalho unidadeTrabalho, IRepositorioUser repositorioUser) : base(unidadeTrabalho)
        {            
            _repositorioUser = repositorioUser;            
        }
        public UserDto Save(UserDto userDto)
        {
            var userMap = _repositorioUser.GetByEmail(userDto.Email);

            if (userMap != null)
            {                                
                userMap.Email = userDto.Email;
                userMap.ImagePerfil = userDto.ImagemPerfil;
                userMap.EmailConfirmed = userDto.EmailConfirmed;
                userMap.NickName = userDto.NickName;                
                userMap.PhoneNumber = userDto.PhoneNumber;
                userMap.Id = userDto.UserId;
                userMap.Guid = new Guid();
                userMap.PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;
                userMap.LastAcess = DateTime.Now;
                userMap.Profession = userDto.Profession;
                userMap.FirstName = userDto.FirstName;
                userMap.Identity = userDto.Identity;
                userMap.LastName = userDto.LastName;
                userMap.ObjectState = ObjectState.Modified;
                // userMap.GroupUserMap = new GroupUserMap(GroupUserEnum.None);//TODO: Implementar processo para salvar tipo de perfil
            }
            else
            {
                userMap = new AspNetUser
                {
                    
                    Email = userDto.Email,
                    ImagePerfil = userDto.ImagemPerfil,                    
                    EmailConfirmed = userDto.EmailConfirmed,
                    NickName = userDto.NickName,                    
                    PhoneNumber = userDto.PhoneNumber,                   
                    Id = userDto.UserId,
                    Guid = new Guid(),                                           
                    PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                    LastAcess = DateTime.Now,
                    Profession = userDto.Profession,
                    FirstName = userDto.FirstName,
                    Identity = userDto.Identity,
                    LastName = userDto.LastName,
                    ObjectState = ObjectState.Added,
                    //GroupUserMap = new GroupUserMap(GroupUserEnum.None)
                };
            }

            _repositorioUser.Save(userMap);            

            return GetById(userMap.Id);
        }

        public UserDto GetById(string id)
        {
            return  AdapterUser.ConverterMapParaDto(_repositorioUser.GetById(id));
        }

        public List<UserDto> GetAll()
        {
            return AdapterUser.ConverterMapParaDto(_repositorioUser.GetAll());
        }

        public void Delete(string id)
        {
            if (id != null)
                return;
            _repositorioUser.Delete(id);
        }

        public UserDto GetByEmail(string email)
        {
            return AdapterUser.ConverterMapParaDto(_repositorioUser.GetByEmail(email));
        }

        public UserDto GetByName(string name)
        {
            return AdapterUser.ConverterMapParaDto(_repositorioUser.GetByName(name));
        }

        public User Autenticar(ComandUser comando)
        {
            User user = AdapterUser.ConverterDtoParEntidade(GetByEmail(comando.NickName));
            return user.ValidarNomeUsuarioESenha(comando.NickName, comando.Senha) ? user : null;
        }

        public IEnumerable<GroupUserDto> GetGroupUser()
        {
            return AdapterUser.ConvertMapToDto(_repositorioUser.GetGroupUser());
        }
    }
}
