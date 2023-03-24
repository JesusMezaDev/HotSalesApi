using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Settlements.Queries
{
    internal class GetCustomerByIdQueryHandler: IRequestHandler<GetSettlementsByPCQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetCustomerByIdQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetSettlementsByPCQueryRequest request, CancellationToken cancellationToken)
        {
            var dbSettlements = new GetSettlementsFromDataBase(_sqlConnectoinFactory);
            var response = await dbSettlements.GetSettlementsByPC(request.PC);
            return response;
        }
    }
}
