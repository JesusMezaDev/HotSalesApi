namespace HotSalesCore.Features.Products.Models
{
    internal class ProductModel
    {
        public int Product_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCategory_Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean Active { get; set; }
    }
}
