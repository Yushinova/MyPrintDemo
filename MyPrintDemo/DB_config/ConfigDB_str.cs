using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPrintDemo.DB_config
{
    public class ConfigDB_str
    {
        public string? connection_str {  get; set; }
        public override string ToString()
        {
            return $"{connection_str}";
        }

    }
}
