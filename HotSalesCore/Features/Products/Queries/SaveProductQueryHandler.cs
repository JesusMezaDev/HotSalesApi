using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Products.Queries
{
    internal class SaveProductQueryHandler: IRequestHandler<SaveProductQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SaveProductQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SaveProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.SaveProduct(request);
            return response;
        }
    }
}
