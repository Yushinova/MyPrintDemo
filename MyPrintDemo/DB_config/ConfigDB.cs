using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.Xml.Linq;

namespace MyPrintDemo.DB_config
{
    public class ConfigDB
    {
        public string? DataSource {  get; set; }
        public string? NameDb {  get; set; }
        public override string ToString()
        {
            return $"Server={DataSource};Database={NameDb};Trusted_Connection=True";
        }
        public string GetConfigDB()
        {
            SqlConnection test = new SqlConnection($"Server={DataSource};Database ={NameDb};Trusted_Connection=True");
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
            catch (Exception ex) { }
            if(test_str=="")
            {
                return test_str;
            }
            else { return this.ToString(); }
        }
    }
    
    
}
