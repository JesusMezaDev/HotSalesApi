using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Customers.Queries
{
    internal class SaveCustomerQueryHandler: IRequestHandler<SaveCustomerQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public SaveCustomerQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(SaveCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var dbCustomers = new GetCustomersFromDataBase(_sqlConnectoinFactory);
            var response = await dbCustomers.SaveCustomer(request);
            return response;
        }
    }
}
