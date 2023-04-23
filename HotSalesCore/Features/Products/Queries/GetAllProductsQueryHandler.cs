using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSalesCore.Features.Products.Queries
{
    internal class GetAllProductsQueryHandler: IRequestHandler<GetAllProductsQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetAllProductsQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.GetAllProducts(request);
            return response;
        }
    }
}
