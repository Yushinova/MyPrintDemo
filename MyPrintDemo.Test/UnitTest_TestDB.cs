using MyPrintDemo.DB_config;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace MyPrintDemo.Test
{
    public class UnitTest_TestDB
    {
        [Fact]
        public void TestPositiveTestDB()
        {
            string expected = "Tanya";
            string actual = "";
            var conf = new ConfigDB_str { connection_str="Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\MyPrintDemo\\MyPrintDemo.Test\\TestDB.mdf;Integrated Security=True;" };
            SqlConnection connection = new SqlConnection(conf.ToString());
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                string str = "Select Users.Name from Users where Users.ID_user=1";// читаю имя 1 юзера
                SqlCommand command = new SqlCommand(str, connection);
                actual = command.ExecuteScalarAsync().Result.ToString();

            }
            else connection.Close();
            Assert.Equal(expected,actual);
        }
        [Fact]
        public void TestNegativeTestDB()
        {
            string actual = "";
            var conf = new ConfigDB_str { connection_str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\MyPrintDemo\\MyPrint.Test\\TestDB.mdf;Integrated Security=True;" };
            SqlConnection connection = new SqlConnection(conf.ToString());
            try
            {
                connection.Open();
                string str = "Select Users.Name from Users where Users.ID_user=1";
                SqlCommand command = new SqlCommand(str, connection);
                actual = command.ExecuteScalarAsync().Result.ToString();
            }
            catch { Exception ex; }  
            Assert.Empty(actual);
        }
    }
}
