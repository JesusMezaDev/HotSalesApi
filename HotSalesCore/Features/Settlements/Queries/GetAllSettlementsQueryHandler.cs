using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Settlements.Queries
{
    internal class GetAllSettlementsQueryHandler: IRequestHandler<GetAllSettlementsQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetAllSettlementsQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetAllSettlementsQueryRequest request, CancellationToken cancellationToken)
        {
            var dbSettlements = new GetSettlementsFromDataBase(_sqlConnectoinFactory);
            var response = await dbSettlements.GetAllSettlements();
            return response;
        }
    }
}
