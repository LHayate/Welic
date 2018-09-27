using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Welic.App.Services.API;
using Welic.App.Services.ServiceViews;
using Xamarin.Forms;

namespace Welic.App.Models.Usuario
{
    public class UserDto
    {
        [SQLite.PrimaryKey]
        public string Email { get; set; }
        public int Id { get; set; }
        public Guid Guid { get; set; }        
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public string NomeCompleto { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string NomeImage { get; set; }
        public DateTime UltimoAcesso { get; set; }

        public UserDto()
        {
            
        }

        public bool RegistrarUsuario(/*string userName, string password, string email*/)
        {            
            //Insere o registro
            DatabaseManager dbManager = new DatabaseManager();
           
            try
            {
                dbManager.database.InsertOrReplace(this);
                dbManager.database.Close();
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
           
        }

        public async void AtualizaUsuario(UserDto user)
        {
            var userDto = await WebApi.Current.GetAsync<UserDto>($"getbyemail/{user.Email}");

            if (userDto != null)
            {
                Id = userDto.Id;
                Guid = userDto.Guid;
                Email = userDto.Email;
                NomeCompleto = userDto.NomeCompleto;
                NomeImage = userDto.NomeImage;
                Password = userDto.Password;
                ConfirmPassword = userDto.ConfirmPassword;                
                EmailConfirmed = userDto.EmailConfirmed;
                ImagemPerfil = userDto.ImagemPerfil;
                PhoneNumberConfirmed = userDto.PhoneNumberConfirmed;
                RememberMe = userDto.RememberMe;
                EmailConfirmed = userDto.EmailConfirmed;
                UltimoAcesso = DateTime.Now;
                UserName = userDto.UserName;
            }
            else
            {

            }

            try
            {
                RegistrarUsuario();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw;
            }                           
        }


        public bool DesconectarUsuario()
        {
            try
            {
                DatabaseManager dbManager = new DatabaseManager();
                var usuarios = dbManager.database.Table<UserDto>()
                    .Where(x => x.RememberMe)
                    .ToList();
                foreach (var usuario in usuarios)
                    usuario.RememberMe = false;
                dbManager.database.UpdateAll(usuarios);
                return true;
            }
            catch { return false; }
        }

        public UserDto LoadAsync()
        {
            DatabaseManager dbManager = new DatabaseManager();
            var usu = dbManager.database.Table<UserDto>()
                .Where(x => x.RememberMe)
                .ToList();
            return usu[0];
        }

        public bool RegisterPhoto(byte[] photo)
        {
            //Insere o registro
            DatabaseManager dbManager = new DatabaseManager();

            try
            {
                dbManager.database.InsertOrReplace(this);
                dbManager.database.Close();
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        internal async Task<bool> RegisterPhoto(MediaFile file)
        {
            var user = this.LoadAsync();
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                user.ImagemPerfil =  memoryStream.ToArray();                
            }
            
            //Insere o registro
            DatabaseManager dbManager = new DatabaseManager();

            try
            {
                await WebApi.Current.PostAsync<UserDto>("user/save", user);

                dbManager.database.InsertOrReplace(user);
                dbManager.database.Close();
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }


  
}
