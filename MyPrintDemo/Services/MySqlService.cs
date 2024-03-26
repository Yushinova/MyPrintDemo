using MyPrintDemo.DB_config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace MyPrintDemo.Services
{
    public class MySqlService<T>
    {
        private readonly SqlConnection _db;
        public MySqlService(string ds, string nDB)
        {
            ConfigDB config = new ConfigDB { DataSource=ds, NameDb=nDB};
            var connectionstr = config.GetConfigDB();
            if(string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception($"Ошибка строки подключения {config.ToString()}");
            }
            else { _db = new SqlConnection(connectionstr); }           
        }
        public async Task<IEnumerable<T>> GetValuesAsync(string table_name)
        {
            await _db.OpenAsync();
            var sql = $"Select * from {table_name}";
            IEnumerable<T> values = await _db.QueryAsync<T>(sql);
            await _db.CloseAsync();
            return values;
        }
    }
}
