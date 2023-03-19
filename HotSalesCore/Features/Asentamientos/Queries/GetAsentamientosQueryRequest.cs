using MediatR;

using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Asentamientos.Queries
{
    public class GetAsentamientosQueryRequest: IRequest<ApiResponseModel>
    {
        public String? CP { get; set; }
    }
}
