using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Products.Queries
{
    public class UpdateProductQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Product_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(2000)]
        public string? Description { get; set; }

        [Range(1, Int32.MaxValue)]
        [AllowNull]
        public int? ProductCategory_Id { get; set; }
    }
}
