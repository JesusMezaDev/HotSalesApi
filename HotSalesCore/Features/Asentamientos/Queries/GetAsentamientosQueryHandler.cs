using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Data;

namespace HotSalesCore.Features.Asentamientos.Queries
{
    internal class GetAsentamientosQueryHandler: IRequestHandler<GetAsentamientosQueryRequest, ApiResponseModel>
    {
        private readonly SqlConnectionFactory _sqlConnectoinFactory;

        public GetAsentamientosQueryHandler(SqlConnectionFactory sqlConnectoinFactory)
        {
            _sqlConnectoinFactory = sqlConnectoinFactory;
        }

        public async Task<ApiResponseModel> Handle(GetAsentamientosQueryRequest request, CancellationToken cancellationToken)
        {
            var dbAsentamientos = new GetAsentamientosFromDataBase(_sqlConnectoinFactory);
            var response = await dbAsentamientos.GetAsentamientos(request.CP);
            return response;
        }
    }
}
