using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Products.Queries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class ProductCategoriesFromDataBase
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public ProductCategoriesFromDataBase(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ApiResponseModel> SearchProductCategories(string searchTerm)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Search_ProductCategories", conn);
                sqlCommand.Parameters.Add("@Search_Term", SqlDbType.VarChar, 50).Value = searchTerm;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> GetProductCategoryById(int productCategoryId)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_ProductCategoryById", conn);
                sqlCommand.Parameters.Add("@ProductCategory_Id", SqlDbType.Int).Value = productCategoryId;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> GetAllProductCategories()
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Get_AllProductCategories", conn);
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> DeleteProductCategory(int productCategoryId)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Delete_ProductCategory", conn);
                sqlCommand.Parameters.Add("@ProductCategory_Id", SqlDbType.Int).Value = productCategoryId;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> SaveProductCategory(SaveProductCategoryQueryRequest saveProductCategoryQueryRequest)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Save_ProductCategory", conn);
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = saveProductCategoryQueryRequest.Name;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 2000).Value = saveProductCategoryQueryRequest.Description;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }

        public async Task<ApiResponseModel> UpdateProductCategory(UpdateProductcategoryQueryRequest updateProductcategoryQueryRequest)
        {
            using (var conn = await _sqlConnectionFactory.GetSqlConnection())
            {
                SqlCommand sqlCommand = _sqlConnectionFactory.CreateNewSqlCommand("HotSales..Update_ProductCategory", conn);
                sqlCommand.Parameters.Add("@ProductCategory_Id", SqlDbType.Int).Value = updateProductcategoryQueryRequest.ProductCategory_Id;
                sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = updateProductcategoryQueryRequest.Name;
                sqlCommand.Parameters.Add("@Description", SqlDbType.VarChar, 2000).Value = updateProductcategoryQueryRequest.Description;
                return _sqlConnectionFactory.ExecuteSqlCommand(sqlCommand);
            }
        }
    }
}
