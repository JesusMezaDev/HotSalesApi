using MediatR;
using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class SearchProductCategoryQueryHandler: IRequestHandler<SearchProductCategoryQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SearchProductCategoryQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SearchProductCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategories = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategories.SearchProductCategories(request.Search_Term);
            return response;
        }
    }
}
