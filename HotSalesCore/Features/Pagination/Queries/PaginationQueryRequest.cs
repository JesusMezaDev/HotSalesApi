using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HotSalesCore.Features.Pagination.Queries
{
    public class PaginationQueryRequest
    {
        [AllowNull]
        [Range(1, Int32.MaxValue)]
        public int Page { get; set; } = 1;
        
        private readonly int MaxRecordsByPage = 50;
        
        private int _recordsByPage = 20;

        [AllowNull]
        [Range(1, 50)]
        public int RecordsByPage
        {
            get { return _recordsByPage; }
            set { _recordsByPage = (value > MaxRecordsByPage) ? MaxRecordsByPage : value; }
        }
    }
}
