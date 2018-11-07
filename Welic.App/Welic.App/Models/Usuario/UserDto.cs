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
        public string UserId { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }         
        public bool EmailConfirmed { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }                            
        public byte[] ImagemPerfil { get; set; }        
        public DateTime LastAcess { get; set; }

        public bool RememberMe { get; set; } //Apenas para Controle de SQLite
        public bool Synced { get; set; } //false to not sinced - true sinced        

        private DatabaseManager _dbManager;
        public UserDto()
        {
            
        }

        public async Task<bool> RegisterUserManager(UserDto user )
        {           
            try
            {
                //user = userBanco.Result;

                UserId = user.UserId;
                Guid = user.Guid;
                NickName = user.NickName;
                Email = user.Email;
                EmailConfirmed = user.EmailConfirmed;
                FirstName = user.FirstName;
                LastName = user.LastName;
                FullName = user.FullName;
                Profession = user.Profession;
                Password = user.Password;
                ImagemPerfil = user.ImagemPerfil;
                PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                Synced = false;
                LastAcess = DateTime.Now;
                RememberMe = true;

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
                    .Where(x => x.Synced == false)                        
                    .ToList();

                if (usu == null) return true;
                foreach (var item in usu)
                {
                    if (!item.Synced)
                    {                        
                        //item.Password = Criptografia.Decriptar(item.Password);
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
                
                var users = _dbManager.database.Table<UserDto>()
                    .Where(x => x.RememberMe)
                    .ToList();

                foreach (var user in users)
                {
                    user.RememberMe = false;
                    _dbManager.database.Delete(user);
                }
                    

                         
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
                .OrderByDescending(c => c.LastAcess)
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
                user.Synced = false;                
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

            var usersalvo = new UserDto()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                NickName = user.NickName,
                RememberMe = true,
                LastName = user.LastName,
                LastAcess = user.LastAcess,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FullName = user.FullName,
                Guid = user.Guid,
                ImagemPerfil = user.ImagemPerfil,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                Profession = user.Profession,
                Synced = this.Synced,
            };                       
            _dbManager.database.InsertOrReplace(usersalvo);
            _dbManager.database.Close();
        }

        public async Task<bool> Register(UserDto userDto)
        {            
            try
            {                                                            
                var user = await WebApi.Current.PostAsync<UserDto>("user/save", userDto);

                Synced = true;
                SaveUser(user); 

                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                throw new System.Exception("Error: In Register this User");
            }
        }

        
    }  
}
