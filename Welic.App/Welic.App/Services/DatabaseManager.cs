

using SQLite;
using Xamarin.Forms;

namespace Welic.App.Services
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
            database = DependencyService.Get<ISQLite>().GetConnection();  
    }

}
}
