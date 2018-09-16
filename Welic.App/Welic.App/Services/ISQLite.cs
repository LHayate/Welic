using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Welic.App.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
