using HotSalesCore.Features.ApiResponse.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class UpdateProductcategoryQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductCategory_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(2000)]
        public string? Description { get; set; }
    }
}
