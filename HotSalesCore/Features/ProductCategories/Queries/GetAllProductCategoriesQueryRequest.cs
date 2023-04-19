using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class GetAllProductCategoriesQueryRequest: IRequest<ApiResponseModel>
    {
    }
}
