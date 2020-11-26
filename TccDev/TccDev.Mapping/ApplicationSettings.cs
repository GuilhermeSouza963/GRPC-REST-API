using System;
using System.Collections.Generic;
using System.Text;

namespace TccDev.Mapping
{
    public class ApplicationSettings
    {
        public static string ConnectionStringSql { get; set; }
        public static string ConnectionStringMySql { get; set; }
        public static string ConnectionStringMongoDb { get; set; }
    }
}
