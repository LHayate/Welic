using SQLite;
using Welic.App.Models.Config;
using Welic.App.Models.Token;
using Welic.App.Models.Usuario;
using Welic.App.Services.ServicesViewModels;
using Xamarin.Forms;

namespace Welic.App.Services.ServiceViews
{
    public interface IkeyObject
    {
        [PrimaryKey, AutoIncrement]
        string Key { get; set; }
    }
    
    public class DatabaseManager
    {
        public SQLiteConnection database;

        public DatabaseManager()
        {
            database = Xamarin.Forms.DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<UserDto>();
            database.CreateTable<UserToken>();
            database.CreateTable<ConfigDto>();
        }
    }
}
