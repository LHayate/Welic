using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Welic.App.Models.Token;
using Welic.App.Services.API;
using Welic.App.Services.Criptografia;
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
        public bool Synced { get; set; } //false to not sinced - true sinced        

        private DatabaseManager _dbManager;
        public UserDto()
        {
            
        }

        public async Task<bool> RegisterUser(UserDto user )
        {           
            try
            {

               
                //user = userBanco.Result;

                Id = user.Id;
                Guid = user.Guid;
                UserName = user.UserName;
                Email = user.Email;
                NomeCompleto = user.NomeCompleto;
                NomeImage = user.NomeImage;
                Password = user.Password;
                ConfirmPassword = user.ConfirmPassword;
                EmailConfirmed = user.EmailConfirmed;
                ImagemPerfil = user.ImagemPerfil;
                PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                RememberMe = true;
                Synced = false;
                UltimoAcesso = DateTime.Now;
                
                //Insere o registro                
                
                try
                {
                   SaveUser(this);
                                        
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
                Console.WriteLine(e);
                return false;
            }                           
        }

        public async Task<UserDto> GetUserbyServer(string email)
        {
            //Faço a atualização do Servidor para Atualizar o Mando SQLite
            var userDto = await  WebApi.Current.GetAsync<UserDto>($"user/GetByEmail?Email={email}");
            return userDto;
        }

        public async Task<bool> SyncedUser()
        {                               
            _dbManager = new DatabaseManager();
            try
            {                
                //Verifico se existe alguma alteração a ser sincronizada com o Servidor
                var usu = _dbManager.database.Table<UserDto>()
                    .Where(x => x.RememberMe && x.Synced == false)                        
                    .ToList();

                if (usu == null) return true;
                foreach (var item in usu)
                {
                    if (!item.Synced)
                    {
                        item.ConfirmPassword = Criptografia.Decriptar(item.ConfirmPassword);
                        item.Password = Criptografia.Decriptar(item.Password);
                        var user = await WebApi.Current.PostAsync<UserDto>("user/save", item);

                        Synced = true;
                        SaveUser(user);
                    }
                }
               
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
               throw new System.Exception("Error: In Synced this User");
            }           
        }

        public async Task<bool> DesconectarUsuario()
        {
            try
            {
                _dbManager = new DatabaseManager();
               
                _dbManager.database.DeleteAll<UserDto>();
                _dbManager.database.DeleteAll<UserToken>();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public UserDto LoadAsync()
        {
            _dbManager = new DatabaseManager();
            var usu = _dbManager.database.Table<UserDto>()
                .Where(x => x.RememberMe) 
                .OrderByDescending(c => c.UltimoAcesso)
                .ToList();
            return usu.FirstOrDefault();
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

            SaveUser(user);
            try
            {
                //try
                //{ 
                //    await SyncedUser();                    
                //}
                //catch
                //{
                    user.Synced = false;
                //}

                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void SaveUser(UserDto user)
        {
            _dbManager = new DatabaseManager();

            _dbManager.database.InsertOrReplace(user);
            _dbManager.database.Close();
        }
    }  
}
