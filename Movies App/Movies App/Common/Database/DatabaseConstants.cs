using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Movies_App.Common.Database
{
 public static   class DatabaseConstants
    {
        public const string DatabaseFileName = "MoviesSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            //open database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //creates the database if doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
