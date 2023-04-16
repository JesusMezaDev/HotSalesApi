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
    internal class UpdateProductQueryHandler: IRequestHandler<UpdateProductQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public UpdateProductQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(UpdateProductQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProducts = new ProductsFromDataBase(_sqlConnectoinFactory);
            var response = await dbProducts.UpdateProduct(request);
            return response;
        }
    }
}
