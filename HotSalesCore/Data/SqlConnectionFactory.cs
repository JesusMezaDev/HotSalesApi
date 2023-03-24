using HotSalesCore.Features.ApiResponse.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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

        public SqlCommand CreateNewSqlCommand(String commandText, SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = commandText;
            sqlCommand.Connection = sqlConnection;

            sqlCommand.Parameters.Clear();
            sqlCommand.Parameters.Add("@Response", SqlDbType.VarChar, 8000).Value = String.Empty;
            sqlCommand.Parameters["@Response"].Direction = ParameterDirection.InputOutput;

            return sqlCommand;
        }

        public ApiResponseModel ExecuteSqlCommand(SqlCommand sqlCommand)
        {
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet("Data");
                sqlDataAdapter.Fill(dataSet);

                String response = sqlCommand.Parameters["@Response"].Value.ToString()!.Trim();

                if (response.Contains("Tables"))
                {
                    Int32 indexStart = response.IndexOf("Tables=");
                    String tablesSubString = response.Substring(indexStart, response.Length - indexStart);
                    String[] tablesSplit = tablesSubString.Split('=');
                    String tables = tablesSplit[1].Replace("|", "");
                    String[] tablesArray = tables.Split(",");
                    indexStart = 0;
                    foreach (String table in tablesArray)
                    {
                        dataSet.Tables[indexStart].TableName = table;
                        indexStart++;
                    }
                }

                return new ApiResponseModel() { Ok = true, Data = dataSet };
            }
            catch (Exception oError)
            {
                return new ApiResponseModel() { Ok = false, Message = oError.Message, Data = null };
            }
        }
    }
}
