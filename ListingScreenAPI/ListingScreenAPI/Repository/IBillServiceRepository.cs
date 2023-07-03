using ListingScreenAPI.Model.DataContract.Request;

namespace ListingScreenAPI.Repository
{
    public interface IBillServiceRepository
    {
        Task<IEnumerable<BillRequest>> GetBillNumber(string billNo);
        Task<CustomerBillRequest> PostCustomer(CustomerBillRequest customer);
        Task<ItemRequest> PostCustomerItemBill(ItemRequest customerItemBill);
        Task<IEnumerable<ItemRequest>> GetCustomerItemBill(int BillNo);
        Task<ItemRequest> DELETECustomerItemBill(int BillNo);

    }
}
