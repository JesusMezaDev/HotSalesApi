using MediatR;
using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class DeleteProductCategoryQueryHandler: IRequestHandler<DeleteProductCategoryQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public DeleteProductCategoryQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(DeleteProductCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategories = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategories.DeleteProductCategory(request.ProductCategory_Id);
            return response;
        }
    }
}
