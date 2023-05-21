using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Products.Queries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotSalesCore.Features.Customers.Queries
{
    internal class GetCustomersFromDataBase
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public GetCustomersFromDataBase(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ApiResponseModel> SearchCustomer(SearchCustomerQueryRequest searchCustomerQueryRequest)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Search_Customers", conn);
                _sqlConnectionFactory.AddPaginationSqlCommand(sqlCommand, searchCustomerQueryRequest.Page, searchCustomerQueryRequest.RecordsByPage);
                sqlCommand.Parameters.Add("@Search_Term", SqlDbType.VarChar, 50).Value = searchCustomerQueryRequest.SearchTerm.Trim();
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> GetCustomerById(int customerId)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_CustomerById", conn);
                sqlCommand.Parameters.Add("@Customer_Id", SqlDbType.Int).Value = customerId;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> SaveCustomer(SaveCustomerQueryRequest saveCustomerQueryRequest)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Save_Customer", conn);
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = saveCustomerQueryRequest.Name;
                sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = saveCustomerQueryRequest.LastName;
                sqlCommand.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = saveCustomerQueryRequest.Gender;
                sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = saveCustomerQueryRequest.Email;
                sqlCommand.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = saveCustomerQueryRequest.Phone;
                sqlCommand.Parameters.Add("@BirthDate", SqlDbType.Date).Value = saveCustomerQueryRequest.BirthDate;
                sqlCommand.Parameters.Add("@ImageUrl", SqlDbType.VarChar, 100).Value = saveCustomerQueryRequest.ImageUrl;
                sqlCommand.Parameters.Add("@Annotations", SqlDbType.VarChar, 2000).Value = saveCustomerQueryRequest.Annotations;
                sqlCommand.Parameters.Add("@Settlement_Id", SqlDbType.Int).Value = saveCustomerQueryRequest.Settlement_Id;
                sqlCommand.Parameters.Add("@StreetAddress", SqlDbType.VarChar, 50).Value = saveCustomerQueryRequest.StreetAddress;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }
    }
}
