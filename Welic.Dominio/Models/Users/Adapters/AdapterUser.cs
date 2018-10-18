using System.Collections.Generic;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Users.Adapters
{
    public class AdapterUser
    {
        public static UserDto ConverterMapParaDto(UserMap userMap)
        {

            if (userMap == null)
            {
                return null;
            }

            UserDto userDto = new UserDto
            {
                Id = userMap.Id,
                IdGuid = userMap.Guid,
                Password = userMap.Password,
                Email = userMap.Email,
                ImagemPerfil = userMap.ImagemPerfil,
                RememberMe = userMap.RememberMe,
                EmailConfirmed = userMap.EmailConfirmed,
                UserName = userMap.UserName,
                NomeCompleto = userMap.NomeCompleto,
                PhoneNumber = userMap.PhoneNumber,
                ConfirmPassword = userMap.ConfirmPassword,
               
               
                NomeImage = userMap.NomeImage,
                PhoneNumberConfirmed = userMap.PhoneNumberConfirmed,
                UltimoAcesso = userMap.UltimoAcesso
            };
           

            return userDto;
        }

        public static Entidades.User ConverterDtoParEntidade(UserDto userDto)
        {

            if (userDto == null)
            {
                return null;
            }

            Entidades.User user = new Entidades.User
            {
                Id = userDto.Id,
                Guid = userDto.IdGuid,
                Password = userDto.Password,
                Email = userDto.Email,
                ImagemPerfil = userDto.ImagemPerfil,
                RememberMe = userDto.RememberMe,
                EmailConfirmed = userDto.EmailConfirmed,
                UserName = userDto.UserName,
                NomeCompleto = userDto.NomeCompleto,
                PhoneNumber = userDto.PhoneNumber,
                ConfirmPassword = userDto.ConfirmPassword,


                NomeImage = userDto.NomeImage,
                PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                UltimoAcesso = userDto.UltimoAcesso
            };


            return user;
        }

        public static List<UserDto> ConverterMapParaDto(List<UserMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<UserDto> listaDto = new List<UserDto>();

            foreach (UserMap map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
    }
}
