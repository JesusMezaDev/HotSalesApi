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
    internal class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetProductByIdQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.GetProductById(request.Product_Id);
            return response;
        }
    }
}
