using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotSalesCore.Features.Asentamientos.Queries
{
    internal class GetAsentamientosFromDataBase
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public GetAsentamientosFromDataBase(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ApiResponseModel> GetAsentamientos(String codigoPostal)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "Direcciones..Get_AsentamientosByCP";
                sqlCommand.Connection = conn;

                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@CP", System.Data.SqlDbType.VarChar, 5).Value = codigoPostal;
                sqlCommand.Parameters.Add("@Response", System.Data.SqlDbType.VarChar, 8000).Value = String.Empty;
                sqlCommand.Parameters["@Response"].Direction = System.Data.ParameterDirection.InputOutput;

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
}
