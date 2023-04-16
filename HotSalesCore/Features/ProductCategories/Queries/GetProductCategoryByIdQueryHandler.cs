using MediatR;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class GetProductCategoryByIdQueryHandler: IRequestHandler<GetProductCategoryByIdQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetProductCategoryByIdQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetProductCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategory = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategory.GetProductCategoryById(request.ProductCategory_Id);
            return response;
        }
    }
}
