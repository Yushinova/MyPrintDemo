using System.Data.SqlClient;
using System.Xml.Linq;

namespace MyPrintDemo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestPositive()
        {
            string expected = "Server=DESKTOP-H7HCK7B\\SQLEXPRESS;Database=MyPrint;Trusted_Connection=True";
            var conf = new DB_config.ConfigDB { DataSource= "DESKTOP-H7HCK7B\\SQLEXPRESS", NameDb="MyPrint" };
            string fact = conf.GetConfigDB().ToString();
            Assert.Equal(expected, fact);
        }
        [Fact]
        public void TestNegative()
        {
            var conf = new DB_config.ConfigDB { DataSource = "DESKTOP-H7HCK7B\\SQLEXPRESSdd", NameDb = "MyPrint" };
            string fact = conf.GetConfigDB().ToString();
            Assert.Empty(fact);
        }
    }
}