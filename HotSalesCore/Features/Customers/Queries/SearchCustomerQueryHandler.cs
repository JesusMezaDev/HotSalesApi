using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Customers.Queries
{
    internal class SearchCustomerQueryHandler: IRequestHandler<SearchCustomerQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SearchCustomerQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SearchCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var dbCustomers = new GetCustomersFromDataBase(_sqlConnectoinFactory);
            var response = await dbCustomers.SearchCustomer(request);
            return response;
        }
    }
}
