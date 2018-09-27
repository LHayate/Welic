using System;
using System.IO;
using System.IO.IsolatedStorage;
using Windows.Storage;
using SQLite;
using Welic.App.Services.ServicesViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(Welic.App.UWP.SQLite))]
namespace Welic.App.UWP
{
    public class SQLite : ISQLite
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
