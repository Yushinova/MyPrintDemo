using System.Data.SqlClient;
using System.Xml.Linq;

namespace MyPrintDemo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestPositive()
        {
            string name = "";
            var conf = new DB_config.ConfigDB { DataSource= "DESKTOP-Q6DF710\\SQLEXPRESS", NameDb="MyPrint" };
           SqlConnection connection = new SqlConnection(conf.ToString());
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                string str = "Select top 0 * from Users";
                SqlCommand command = new SqlCommand(str, connection);
                name = command.ExecuteReader().ToString();
 
            }
            else connection.Close();
            Assert.NotEmpty(name);
        }
        [Fact]
        public void TestNegative()
        {
            string name = "";
            var conf = new DB_config.ConfigDB { DataSource = "DESKTOP-Q6DF710\\SQLEXPRESSdd", NameDb = "MyPrint" };
            SqlConnection connection = new SqlConnection(conf.ToString());
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    string str = "Select top 0 * from Users";
                    SqlCommand command = new SqlCommand(str, connection);
                    name = command.ExecuteScalar().ToString();
                }
                else connection.Close();
            }
            catch (Exception) { };
            Assert.Empty(name);
        }
    }
}