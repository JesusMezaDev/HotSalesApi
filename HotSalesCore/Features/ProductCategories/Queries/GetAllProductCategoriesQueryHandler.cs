using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    internal class GetAllProductCategoriesQueryHandler: IRequestHandler<GetAllProductCategoriesQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetAllProductCategoriesQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetAllProductCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var dbProductCategories = new ProductCategoriesFromDataBase(_sqlConnectoinFactory);
            var response = await dbProductCategories.GetAllProductCategories();
            return response;
        }
    }
}
