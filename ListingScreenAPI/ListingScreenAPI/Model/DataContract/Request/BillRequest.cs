namespace ListingScreenAPI.Model.DataContract.Request
{
    public class BillRequest
    {
        public int Id { get; set; }
        public string? BillNo { get; set; }
        public string? BillDate { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentType { get; set; }
        public string? Mode { get; set; }
        public string? status { get; set; }



    }
}
