namespace ListingScreenAPI.Model.DataContract.Request
{
    public class ItemRequest
    {
         public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal GST { get; set; }
        public int BillNo { get; set; }
        public decimal Value { get; set; }
        public decimal GSTValue { get; set; }
        public decimal Amount { get; set; }
        public string? status { get; set; }
        public string? Mode { get; set; }
        

    }
}
