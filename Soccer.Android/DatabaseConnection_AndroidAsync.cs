using SQLite;
using LocalDataAccess.Droid;
using System.IO;
using Soccer.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_AndroidAsync))]
namespace LocalDataAccess.Droid
{
    public class DatabaseConnection_AndroidAsync : IDatabaseConnectionAsync
    {
        public SQLiteAsyncConnection DbConnectionAsync()
        {
            var dbName = "DB.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}