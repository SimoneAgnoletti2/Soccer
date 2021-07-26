using Soccer.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Soccer.Controls
{
    public class DatabaseUser
    {
        public async Task<bool> CreateTableUser()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();

                await Database.CreateTableAsync(typeof(Utente));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TableExist(String tableName)
        {
            try
            {
                SQLiteConnection Database = DependencyService.Get<IDatabaseConnection>().DbConnection();
                var tableInfo = Database.GetTableInfo(tableName);
                if (tableInfo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void DropTableUsers()
        {
            try
            {
                SQLiteConnection Database = DependencyService.Get<IDatabaseConnection>().DbConnection();
                List<Utente> v = Database.Query<Utente>("DROP TABLE Utente");

            }
            catch (Exception ex)
            {
            }
        }


        public async Task<Utente> getUser(string name)
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("SELECT * FROM Utente WHERE Nome = '" + name + "'");
                {
                    return v[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


            public async Task<int> existUser(Utente u)
            {
                try
                {
                    SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                    List<Utente> v = await Database.QueryAsync<Utente>("SELECT * FROM Utente WHERE Nome = '" + u.Nome + "' AND Password = '" + u.Password + "'");
                    {
                        return v.Count;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }

            public async Task<Utente> updateUserMantain(string name, int mantain)
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("UPDATE Utente Set Mantain = '" + mantain + "' WHERE Nome = '" + name +"' ");
                {
                    return v[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Utente> getUserMantain()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("SELECT * FROM Utente WHERE Mantain = '1'");
                {
                    return v[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Utente> setMantainUserDisable()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("UPDATE Utente SET Mantain = '0'");
                {
                    return v[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> InsUser(Utente u)
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                int numero = await Database.InsertOrReplaceAsync(u);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
