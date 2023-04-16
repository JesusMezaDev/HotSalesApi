using MediatR;
using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class UpdateProductCategoryQueryHandler: IRequestHandler<UpdateProductcategoryQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public UpdateProductCategoryQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(UpdateProductcategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategories = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategories.UpdateProductCategory(request);
            return response;
        }
    }
}
