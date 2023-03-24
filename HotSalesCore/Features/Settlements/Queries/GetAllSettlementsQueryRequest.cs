using MediatR;

using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Settlements.Queries
{
    public class GetAllSettlementsQueryRequest: IRequest<ApiResponseModel> { }
}
