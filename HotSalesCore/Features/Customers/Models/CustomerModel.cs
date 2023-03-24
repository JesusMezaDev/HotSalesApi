namespace HotSalesCore.Features.Customers.Models
{
    internal class CustomerModel
    {
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public char Generd { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImageUrl { get; set; }
        public string Annotations { get; set; }
        public int Settlement_Id { get; set; }
        public string StreetAddress { get; set; }
    }
}
