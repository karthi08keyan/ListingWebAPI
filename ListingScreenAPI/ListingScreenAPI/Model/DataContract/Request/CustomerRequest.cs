namespace ListingScreenAPI.Model.DataContract.Request
{
    public class CustomerRequest
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }

        public string? Address { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PinCode { get; set; }
        public string? MobileNumber { get; set; }
        public decimal? OutstandingAmount { get; set; }
        public decimal? OutstandingLimit { get; set; }
        
        public string? status { get; set; }
    }
}
