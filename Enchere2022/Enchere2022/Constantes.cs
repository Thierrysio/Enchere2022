using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Enchere2022
{
    class Constantes
    {
        public static string BaseApiAddress => "http://172.17.0.61:8000/";
        public static Random rnd = new Random();
        public const string DatabaseFilename = "Enchere2022.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
