using ListingScreenAPI.Model.DataContract.Request;

namespace ListingScreenAPI.Service
{
    public interface IBillService
    {
        Task<IEnumerable<BillRequest>> GetBillNumber(string customerName);
        Task<CustomerBillRequest> PostCustomer(CustomerBillRequest customer);
        Task<ItemRequest> PostCustomerItemBill(ItemRequest customerItemBill);
        Task<IEnumerable<ItemRequest>> GetCustomerItemBill(int BillNo);
        Task<ItemRequest> DELETECustomerItemBill(int BillNo);

    }
}
