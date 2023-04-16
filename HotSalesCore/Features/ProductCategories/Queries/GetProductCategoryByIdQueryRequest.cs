using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class GetProductCategoryByIdQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ProductCategory_Id { get; set; }
    }
}
