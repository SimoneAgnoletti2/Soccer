using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Controls
{
    public interface IDatabaseConnectionAsync
    {
        SQLite.SQLiteAsyncConnection DbConnectionAsync();
    }
}