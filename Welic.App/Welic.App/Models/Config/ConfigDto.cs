using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.Services.ServiceViews;

namespace Welic.App.Models.Config
{
    public class ConfigDto
    {
        [SQLite.PrimaryKey]
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool Biometria { get; set; }
        private DatabaseManager _dbManager;

        public ConfigDto()
        {
            
        }

        public void CreateConfig( ConfigDto configDto)
        {
            _dbManager = new DatabaseManager();
           
            _dbManager.database.InsertOrReplace(configDto);
            _dbManager.database.Close();
        }






    }
}
