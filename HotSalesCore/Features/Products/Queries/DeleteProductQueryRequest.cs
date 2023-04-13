using System.ComponentModel.DataAnnotations;
using MediatR;
using HotSalesCore.Features.ApiResponse.Models;

namespace HotSalesCore.Features.Products.Queries
{
    public class DeleteProductQueryRequest : IRequest<ApiResponseModel>
    {
        [Required]
        public int Product_Id { get; set; }
    }
}
