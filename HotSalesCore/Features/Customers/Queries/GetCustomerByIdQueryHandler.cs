using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Customers.Queries
{
    internal class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetCustomerByIdQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var dbCustomers = new GetCustomersFromDataBase(_sqlConnectoinFactory);
            var response = await dbCustomers.GetCustomerById(request.Customer_Id);
            return response;
        }
    }
}
