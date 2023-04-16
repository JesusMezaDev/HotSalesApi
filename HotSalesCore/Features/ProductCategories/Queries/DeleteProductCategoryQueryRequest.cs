using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.ProductCategories.Queries
{
    public class DeleteProductCategoryQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        public int ProductCategory_Id { get; set; }
    }
}
