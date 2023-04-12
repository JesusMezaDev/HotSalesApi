using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Customers.Queries;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSalesCore.Features.Products.Queries
{
    internal class ProductsFromDataBase
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public ProductsFromDataBase(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ApiResponseModel> SearchProducts(string searchTerm)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Search_Products", conn);
                sqlCommand.Parameters.Add("@Search_Term", SqlDbType.VarChar, 50).Value = searchTerm;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> GetProductById(int productId)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_ProductById", conn);
                sqlCommand.Parameters.Add("@Product_Id", SqlDbType.Int).Value = productId;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> SaveProduct(SaveProductQueryRequest saveProductQueryRequest)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Save_Product", conn);
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = saveProductQueryRequest.Name;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 2000).Value = saveProductQueryRequest.Description;
                sqlCommand.Parameters.Add("@ProductCategory_Id", SqlDbType.Int).Value = saveProductQueryRequest.ProductCategory_Id;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }
    }
}
