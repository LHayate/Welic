using System;
using System.Collections.Generic;
using Welic.Dominio;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Adapters;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Enums;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Dominio.Utilitarios.Entidades;
using Welic.Dominio.Utilitarios.Enums;

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
                userMap.FullName = userDto.FullName;                
                userMap.Password = Criptografia.Encriptar(userDto.Password);                
                userMap.Id = userDto.Id;
                userMap.EmailConfirmed = userDto.EmailConfirmed;
                userMap.ImagemPerfil = userDto.ImagemPerfil;
                userMap.PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;                
                userMap.EmailConfirmed = userDto.EmailConfirmed;
                userMap.LastAcess = DateTime.Now; 
                userMap.NickName = userDto.NickName;
                userMap.GroupUserMap = new GroupUserMap(GroupUserEnum.None);

            }
            else
            {
                userMap = new UserMap
                {
                    Password = Criptografia.Encriptar(userDto.Password),
                    Email = userDto.Email,
                    ImagemPerfil = userDto.ImagemPerfil,                    
                    EmailConfirmed = userDto.EmailConfirmed,
                    NickName = userDto.NickName,
                    FullName = userDto.FullName,
                    PhoneNumber = userDto.PhoneNumber,                   
                    Id = userDto.Id,
                    Guid = new Guid(),   
                                        
                    PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                    LastAcess = DateTime.Now,
                    GroupUserMap = new GroupUserMap(GroupUserEnum.None)
                };


            }

            _repositorioUser.Save(userMap);

            if (!Commit())
                return null;

            return GetById(userMap.Id);
        }

        public UserDto GetById(int id)
        {
            return  AdapterUser.ConverterMapParaDto(_repositorioUser.GetById(id));
        }

        public List<UserDto> GetAll()
        {
            return AdapterUser.ConverterMapParaDto(_repositorioUser.GetAll());
        }

        public void Delete(int id)
        {
            if (id > 0)
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
            return null;
            //AdapterUser.ConvertMapToDto(_repositorioUser.GetGroupUser());
        }
    }
}
