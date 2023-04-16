using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Products.Queries
{
    public class GetProductByIdQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Product_Id { get; set; }
    }
}
