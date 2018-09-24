using System.IO;
using SQLite;
using Welic.App.Services;
using Welic.App.Services.ServicesViewModels;
using Xamarin.Forms;


[assembly: Dependency(typeof(Welic.App.Droid.Services.SQLite))]
namespace Welic.App.Droid.Services
{
    public class SQLite:ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "Welic.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}