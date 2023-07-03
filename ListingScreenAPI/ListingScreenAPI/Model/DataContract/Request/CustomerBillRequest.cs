using Microsoft.OpenApi.Writers;
using Microsoft.VisualBasic;

namespace ListingScreenAPI.Model.DataContract.Request
{
    public class CustomerBillRequest
    {
       
        public int BillId { get; set; }
        public string? CustomerName { get; set; }
        public decimal? OutstandingAmount { get; set; }
        public decimal? OutstandingLimit { get; set; }
        public string? CustomerDetails { get; set; }
        public string? Billno { get; set; }
        public string? BillDate { get; set; }
        public string? PaymentType { get; set; }

        public int TotalAmount { get; set; }
        public string? Mode { get; set; }
        public string? status { get; set; }

    }
}
