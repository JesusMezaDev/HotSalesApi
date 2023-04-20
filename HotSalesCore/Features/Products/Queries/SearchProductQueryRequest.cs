using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;
using HotSalesCore.Features.Pagination.Queries;

namespace HotSalesCore.Features.Products.Queries
{
    public class SearchProductQueryRequest: PaginationQueryRequest, IRequest<ApiResponseModel>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Search_Term { get; set; }
    }
}
