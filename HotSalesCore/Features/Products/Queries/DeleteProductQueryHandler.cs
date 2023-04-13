using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using MediatR;

namespace HotSalesCore.Features.Products.Queries
{
    internal class DeleteProductQueryHandler : IRequestHandler<DeleteProductQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public DeleteProductQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(DeleteProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.DeleteProduct(request.Product_Id);
            return response;
        }
    }
}
