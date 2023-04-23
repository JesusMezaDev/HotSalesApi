using MediatR;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Pagination.Queries;

namespace HotSalesCore.Features.Products.Queries
{
    public class GetAllProductsQueryRequest: PaginationQueryRequest, IRequest<ApiResponseModel>
    {
    }
}
