using LocalDataAccess.iOS;
using SQLite;
using System;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOSAsync))]
namespace LocalDataAccess.iOS
{
    public class DatabaseConnection_iOSAsync
    {
        public SQLiteAsyncConnection DbConnectionAsync()
        {
            var dbName = "DB.db3";
            string personalFolder =
              System.Environment.
              GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
              Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}