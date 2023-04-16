using MediatR;
using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class SaveProductCategoryQueryHandler: IRequestHandler<SaveProductCategoryQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SaveProductCategoryQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SaveProductCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategories = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategories.SaveProductCategory(request);
            return response;
        }
    }
}
