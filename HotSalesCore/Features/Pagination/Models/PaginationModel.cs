namespace HotSalesCore.Features.Pagination.Models
{
    public class PaginationModel
    {
        public int Page { get; set; } = 1;
        private readonly int MaxRecordsByPage = 50;
        public int _recordsByPage  = 20;
        public int RecordsByPage
        {
            get { return _recordsByPage; }
            set { _recordsByPage = (value > MaxRecordsByPage) ? MaxRecordsByPage : value; }
        }
    }
}
