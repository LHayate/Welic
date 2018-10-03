using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Welic.App.Models.Token;
using Welic.App.Services.API;
using Welic.App.Services.ServiceViews;

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
        public bool Sinced { get; set; } //false to not sinced - true sinced

        private DatabaseManager _dbManager;
        public UserDto()
        {
            
        }

        public async Task<bool> RegisterUser(UserDto user )
        {           
            try
            {
                var userDto = await WebApi.Current.GetAsync<UserDto>($"user/GetByEmail?Email={user.Email}");
            
                Id = userDto.Id == null ? user.Id : userDto.Id;
                Guid = userDto.Guid != null ? userDto.Guid : user.Guid;
                UserName = userDto.UserName;
                Email = userDto.Email?? user.Email ;
                NomeCompleto = userDto.NomeCompleto?? user.NomeCompleto;
                NomeImage = userDto.NomeImage??user.NomeImage;
                Password = userDto.Password?? user.Password;
                ConfirmPassword = userDto.ConfirmPassword??user.ConfirmPassword;
                EmailConfirmed = userDto.EmailConfirmed ? user.EmailConfirmed: userDto.EmailConfirmed;
                ImagemPerfil = userDto.ImagemPerfil??user.ImagemPerfil;
                PhoneNumberConfirmed = userDto.PhoneNumberConfirmed??user.PhoneNumberConfirmed;
                RememberMe = true;
                UltimoAcesso = DateTime.Now;
                
                //Insere o registro                
                _dbManager = new DatabaseManager();

                try
                {
                    _dbManager.database.InsertOrReplace(this);
                    _dbManager.database.Close();
                    
                    //await WebApi.Current.PostAsync<UserDto>("user/save", userDto);
                    return true;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                    throw new System.Exception("Erro ao Gravar o Usuario no SQLite");
                }
            }
            catch (System.Exception e)
            {

                _dbManager = new DatabaseManager();
                _dbManager.database.InsertOrReplace(this);
                _dbManager.database.Close();

                Console.WriteLine(e);
                return false;
            }                           
        }

        public async Task<bool> SyncedUser(UserDto user)
        {
            try
            {

                //Insere o registro                
                _dbManager = new DatabaseManager();

                try
                {
                    _dbManager.database.Update(user);
                    _dbManager.database.Close();

                    await WebApi.Current.PostAsync<UserDto>("user/save", user);
                    return true;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
            catch (System.Exception e)
            {

                _dbManager = new DatabaseManager();
                _dbManager.database.InsertOrReplace(this);
                _dbManager.database.Close();

                Console.WriteLine(e);
                return false;
            }
        }


        public bool DesconectarUsuario()
        {
            try
            {
                
                _dbManager = new DatabaseManager();
                var usuarios = _dbManager.database.Table<UserDto>()
                    .Where(x => x.RememberMe)
                    .ToList();
                foreach (var usuario in usuarios)
                    usuario.RememberMe = false;
                _dbManager.database.UpdateAll(usuarios);

                _dbManager.database.DeleteAll<UserToken>();
                return true;
            }
            catch { return false; }
        }

        public UserDto LoadAsync()
        {
            _dbManager = new DatabaseManager();
            var usu = _dbManager.database.Table<UserDto>()
                .Where(x => x.RememberMe) 
                .OrderByDescending(c => c.UltimoAcesso)
                .ToList();
            return usu[0];
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
            _dbManager = new DatabaseManager();

            try
            {

                try
                {
                    user.Sinced = true;
                    await WebApi.Current.PostAsync<UserDto>("user/save", user);
                }
                catch
                {
                    user.Sinced = false;
                }

                _dbManager.database.InsertOrReplace(user);
                _dbManager.database.Close();
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
