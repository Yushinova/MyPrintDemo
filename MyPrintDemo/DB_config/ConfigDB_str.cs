using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;

namespace MyPrintDemo.DB_config
{
    public class ConfigDB_str
    {
        public string? connection_str { get; set; }

        public string GetFromTXT(string path = "Config_MsSQL.txt")
        {
            using (StreamReader reader = new StreamReader(path))
            {
                connection_str = reader.ReadToEnd();
            }
            return connection_str;
        }
    }
}
