using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using System.ComponentModel.DataAnnotations;

namespace HotSalesCore.Features.Customers.Queries
{
    public class SearchCustomerQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string SearchTerm { get; set; }
    }
}
