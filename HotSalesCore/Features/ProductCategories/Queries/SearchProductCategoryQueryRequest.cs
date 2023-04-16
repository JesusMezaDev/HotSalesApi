using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class SearchProductCategoryQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string SearchTerm { get; set; }
    }
}
