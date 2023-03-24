﻿using MediatR;

using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Settlements.Queries
{
    public class GetSettlementsByPCQueryRequest: IRequest<ApiResponseModel>
    {
        public String? PC { get; set; }
    }
}
