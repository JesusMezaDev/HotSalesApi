using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotSalesCore.Features.Settlements.Queries
{
    internal class GetSettlementsFromDataBase
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public GetSettlementsFromDataBase(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ApiResponseModel> GetSettlementsByPC(String postalCode)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_SettlementsByPC", conn);
                sqlCommand.Parameters.Add("@PC", SqlDbType.VarChar, 5).Value = postalCode;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> GetAllSettlements()
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_AllSettlements", conn);
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }
    }
}
