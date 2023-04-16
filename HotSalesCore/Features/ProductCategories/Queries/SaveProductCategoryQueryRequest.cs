using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class SaveProductCategoryQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(2000)]
        public string? Description { get; set; }
    }
}
