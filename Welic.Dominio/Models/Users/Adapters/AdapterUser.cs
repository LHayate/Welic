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
                Guid = userMap.Guid,
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
