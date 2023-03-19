using Microsoft.Data.SqlClient;

namespace HotSalesCore.Data
{
    public class SqlConnectionFactory
    {
        private readonly String _connectionString;
        public SqlConnectionFactory(String cadenaConexion)
        {
            _connectionString = cadenaConexion;
        }

        public async Task<SqlConnection> GetSqlConnection()
        {
            var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            return conn;
        }
    }
}
