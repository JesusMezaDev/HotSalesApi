using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using System.ComponentModel.DataAnnotations;

namespace HotSalesCore.Features.Customers.Queries
{
    public class GetCustomerByIdQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        public int Customer_Id { get; set; }
    }
}
