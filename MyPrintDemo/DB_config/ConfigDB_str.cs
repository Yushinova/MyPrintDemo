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
        public string GetConfigDB_str()
        {
            SqlConnection test = new SqlConnection(connection_str);
            string test_str = "";
            try
            {
                if (test.State == System.Data.ConnectionState.Closed)
                {
                    test.Open();
                    string str = "Select top 0 * from Users";// читаю шапку таблицы
                    SqlCommand command = new SqlCommand(str, test);
                    test_str = command.ExecuteReader().ToString();
                }
                else test.Close();
            }
            catch (Exception) { }
            if (test_str == "")
            {
                return test_str;
            }
            else { return connection_str; }
        }
    }
}
