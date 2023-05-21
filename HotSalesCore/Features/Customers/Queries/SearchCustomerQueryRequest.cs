using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using System.ComponentModel.DataAnnotations;
using HotSalesCore.Features.Pagination.Queries;

namespace HotSalesCore.Features.Customers.Queries
{
    public class SearchCustomerQueryRequest: PaginationQueryRequest, IRequest<ApiResponseModel>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string SearchTerm { get; set; }
    }
}
