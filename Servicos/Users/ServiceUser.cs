using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welic.Dominio;
using Welic.Dominio.Models.User.Servicos;
using Welic.Dominio.Models.Users.Adapters;
using Welic.Dominio.Models.Users.Comandos;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Entidades;
using Welic.Dominio.Models.Users.Mapeamentos;
using Welic.Dominio.Models.Users.Repositorios;
using Welic.Dominio.Utilitarios.Entidades;

namespace Servicos.Users
{
    public class ServiceUser : Servico, IServiceUser
    {
        private readonly IRepositorioUser _repositorioUser;
        private readonly IUnidadeTrabalho _unidadeTrabalho;

        public ServiceUser(IUnidadeTrabalho unidadeTrabalho, IRepositorioUser repositorioUser) : base(unidadeTrabalho)
        {            
            _repositorioUser = repositorioUser;
            _unidadeTrabalho = unidadeTrabalho;

        }
        public UserDto Save(UserDto userDto)
        {
            var userMap = _repositorioUser.GetByEmail(userDto.Email);

            if (userMap != null)
            {
                userMap.Email = userDto.Email;
                userMap.NomeCompleto = userDto.NomeCompleto;
                userMap.NomeImage = userDto.NomeImage;
                userMap.Password = Criptografia.Encriptar(userDto.Password);
                userMap.ConfirmPassword = Criptografia.Encriptar(userDto.ConfirmPassword);
                userMap.Id = userDto.Id;
                userMap.EmailConfirmed = userDto.EmailConfirmed;
                userMap.ImagemPerfil = userDto.ImagemPerfil;
                userMap.PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;
                userMap.RememberMe = userDto.RememberMe;
                userMap.EmailConfirmed = userDto.EmailConfirmed;
                userMap.UltimoAcesso = DateTime.Now; 
                userMap.UserName = userDto.UserName;

            }
            else
            {
                userMap = new UserMap
                {
                    Password = Criptografia.Encriptar(userDto.Password),
                    Email = userDto.Email,
                    ImagemPerfil = userDto.ImagemPerfil,
                    RememberMe = userDto.RememberMe,
                    EmailConfirmed = userDto.EmailConfirmed,
                    UserName = userDto.UserName,
                    NomeCompleto = userDto.NomeCompleto,
                    PhoneNumber = userDto.PhoneNumber,
                    ConfirmPassword = Criptografia.Encriptar(userDto.ConfirmPassword),
                    Id = userDto.Id,
                    Guid = userDto.Guid,
                    NomeImage = userDto.NomeImage,
                    PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                    UltimoAcesso = DateTime.Now
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
            User user = AdapterUser.ConverterDtoParEntidade(GetByEmail(comando.NomeUsuario));
            return user.ValidarNomeUsuarioESenha(comando.NomeUsuario, comando.Senha) ? user : null;
        }                   
    }
}
