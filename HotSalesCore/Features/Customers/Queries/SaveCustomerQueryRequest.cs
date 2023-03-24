using MediatR;

using HotSalesCore.Features.ApiResponse.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using HotSalesCore.AttributeValidations;

namespace HotSalesCore.Features.Customers.Queries
{
    public class SaveCustomerQueryRequest: IRequest<ApiResponseModel>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [AllowNull]
        [MaxLength(50)]
        public string? LastName { get; set; }
        
        [AllowNull]
        [MaxLength(1)]
        [ValidateGenderAttribute]
        public string? Gender { get; set; }
        
        [AllowNull]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        
        [AllowNull]
        [MaxLength(15)]
        [Phone]
        public string? Phone { get; set; }

        [AllowNull]
        public DateTime? BirthDate { get; set; }

        [AllowNull]
        public string? ImageUrl { get; set; }
        
        [AllowNull]
        [MaxLength(2000)]
        public string? Annotations { get; set; }

        [AllowNull]
        public int? Settlement_Id { get; set; }
        
        [AllowNull]
        [MaxLength(50)]
        public string? StreetAddress { get; set; }
    }
}
