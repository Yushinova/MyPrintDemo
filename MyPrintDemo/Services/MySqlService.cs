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
        public MySqlService(string db = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\MyPrintDemo\\MyPrintDemo.Test\\TestDB.mdf;Integrated Security=True;")
        {
            ConfigDB_str config = new ConfigDB_str { connection_str = db };
            var connectionstr = config.GetConfigDB_str();
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new Exception($"Ошибка строки подключения {db}");
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

        public async Task<T> GetByIdAsync(string table_name, string column_name, int key)
        {
            await _db.OpenAsync();
            var sql = $"Select * from {table_name} where {column_name} = {key}";
            T value = await _db.QuerySingleAsync<T>(sql);
            await _db.CloseAsync();
            return value;

        }

        public async Task UpdateAndInsertAsync(string sql)
        {
            await _db.OpenAsync();
           await _db.ExecuteAsync(sql);
            await _db.CloseAsync();
        }

    }
}
