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
        public MySqlService()
        {
            ConfigDB_str config = new ConfigDB_str();
            var connectionstr = config.GetConfigDB_str();
            if (string.IsNullOrEmpty(connectionstr))
            {
                throw new ArgumentException($"Ошибка строки подключения {connectionstr}");
            }
            else { _db = new SqlConnection(connectionstr); }
        }
        public IEnumerable<T> GetValues(string table_name)
        {
            _db.Open();
            var sql = $"Select * from {table_name}";
            IEnumerable<T> values = _db.Query<T>(sql);
            _db.Close();
            return values;
        }

        public T GetById(string table_name, string column_name, int key)
        {
            _db.Open();
            var sql = $"Select * from {table_name} where {column_name} = {key}";
            T value = _db.QuerySingle<T>(sql);
            _db.Close();
            return value;

        }

        public void UpdateAndInsert(string sql)
        {
            _db.Open();
           _db.Execute(sql);
            _db.Close();
        }

    }
}
