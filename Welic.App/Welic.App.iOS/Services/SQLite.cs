using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using Welic.App.Services.ServicesViewModels;

[assembly: Xamarin.Forms.Dependency(typeof(Welic.App.iOS.Services.SQLite))]
namespace Welic.App.iOS.Services
{
    public class SQLite : ISQLite
    {

        public SQLite()
        {
            
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "localData.db";
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string path = Path.Combine(libFolder, sqliteFilename);
            // This is where we copy in the pre-created database
      //      if (!File.Exists(path))
     //       {
    //            var existingDb = NSBundle.MainBundle.PathForResource("Employee", "db");
   //            File.Copy(existingDb, path);
   //         }
            //var platform = new SQLitePlatformIOS();
            //var param = new SQLiteConnectionString(path, false);
            var connection = new SQLiteConnection(path);
            return connection;                                                        
        }
    }
}