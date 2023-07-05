using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos1._0
{
    internal abstract class DB
    {
        private string _connectionstring;
        protected SqlConnection _connection;

        public DB(string server,string db, string us, string pass)
        {
            _connectionstring = $"Data Source = {server}; Initial Catalog = {db};" +
                $"User = {us}; Password = {pass}";
        }

        public void Open()
        {
            _connection = new SqlConnection(_connectionstring);
            _connection.Open();
        }

        public void Close() 
        {
            if(_connection != null && _connection.State == System.Data.ConnectionState.Open) 
            { 
                _connection.Close();
            }
        }
    }
}
