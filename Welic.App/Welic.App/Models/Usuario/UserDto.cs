using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.Services;
using Welic.App.Services.ServiceViews;

namespace Welic.App.Models.Usuario
{
    public class UserDto
    {
        [SQLite.PrimaryKey]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }
        public bool Conectado { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
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
    }


  
}
