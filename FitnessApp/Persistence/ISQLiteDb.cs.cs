using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FitnessApp.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
