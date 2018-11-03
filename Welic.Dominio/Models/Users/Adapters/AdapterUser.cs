using System.Collections.Generic;
using System.Drawing.Drawing2D;
using Welic.Dominio.Models.Users.Dtos;
using Welic.Dominio.Models.Users.Mapeamentos;

namespace Welic.Dominio.Models.Users.Adapters
{
    public class AdapterUser
    {
        public static UserDto ConverterMapParaDto(AspNetUser userMap)
        {

            if (userMap == null)
            {
                return null;
            }

            UserDto userDto = new UserDto
            {
                UserId = userMap.Id,
                Guid = userMap.Guid,
                Password = userMap.Password,
                Email = userMap.Email,
                ImagemPerfil = userMap.ImagePerfil,                
                EmailConfirmed = userMap.EmailConfirmed,
                NickName = userMap.NickName,                
                Profession = userMap.Profession,
                PhoneNumber = userMap.PhoneNumber,               
                PhoneNumberConfirmed = userMap.PhoneNumberConfirmed,
                LastAcess = userMap.LastAcess,
                FirstName = userMap.FirstName,
                LastName = userMap.LastName,
                Identity = userMap.Identity
                
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
                UserId = userDto.UserId,
                Guid = userDto.Guid,
                Password = userDto.Password,
                Email = userDto.Email,
                ImagemPerfil = userDto.ImagemPerfil,                
                EmailConfirmed = userDto.EmailConfirmed,
                NickName = userDto.NickName,                
                PhoneNumber = userDto.PhoneNumber,                
                PhoneNumberConfirmed = userDto.PhoneNumberConfirmed,
                LastAcess = userDto.LastAcess,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Identity = userDto.Identity,
                Profession = userDto.Profession
                
            };

            return user;
        }

        public static GroupUserDto ConvertMapToDto(GroupUserMap map)
        {
            if (map != null)
                return null;

            return new GroupUserDto
            {
                Id = map.Id,
                Description = map.Description,
                Nivel = map.Nivel
            };

        }

        public static List<UserDto> ConverterMapParaDto(List<AspNetUser> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<UserDto> listaDto = new List<UserDto>();

            foreach (AspNetUser map in listaMap)
            {
                listaDto.Add(ConverterMapParaDto(map));
            }
            return listaDto;
        }
        public static List<GroupUserDto> ConvertMapToDto(List<GroupUserMap> listaMap)
        {
            if (listaMap == null)
            {
                return null;
            }

            List<GroupUserDto> listaDto = new List<GroupUserDto>();

            foreach (GroupUserMap map in listaMap)
            {
                listaDto.Add(ConvertMapToDto(map));
            }
            return listaDto;
        }
    }
}
