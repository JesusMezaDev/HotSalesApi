using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

using MediatR;

using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Products.Queries
{
    public class SaveProductQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(2000)]
        public string? Description { get; set; }

        [AllowNull]
        public int? ProductCategory_Id { get; set; }
    }
}
