using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Controls
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}