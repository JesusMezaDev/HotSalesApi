using MediatR;
using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Pagination.Queries;

namespace HotSalesCore.Features.Products.Queries
{
    internal class SearchProductQueryHandler: IRequestHandler<SearchProductQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SearchProductQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SearchProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.SearchProducts(request);
            return response;
        }
    }
}
