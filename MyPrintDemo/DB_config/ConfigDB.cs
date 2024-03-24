using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyPrintDemo.DB_config
{
    public class ConfigDB
    {
        public string? DataSource {  get; set; }
        public string? NameDb {  get; set; }
        public override string ToString()
        {
            return $"Server={DataSource};Database ={NameDb};Trusted_Connection=True";
        }
    }
    
    
}
