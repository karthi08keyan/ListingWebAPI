using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Repository;

namespace ListingScreenAPI.Service
{
    public class BillSevice:IBillService
    {
        private IBillServiceRepository billServiceRepository;

        public BillSevice(IBillServiceRepository ibillServiceRepository)
        {
            billServiceRepository = ibillServiceRepository;
            
        }
        public async Task<IEnumerable<BillRequest>> GetBillNumber(string billNo)
        {

            return await billServiceRepository.GetBillNumber(billNo);
        }
        public async Task<CustomerBillRequest> PostCustomer(CustomerBillRequest customer)
        {
            return await billServiceRepository.PostCustomer(customer);
        }
        public async Task<ItemRequest> PostCustomerItemBill(ItemRequest customerItemBill)
        {
            return await billServiceRepository.PostCustomerItemBill(customerItemBill);
        }
        public async Task<IEnumerable<ItemRequest>> GetCustomerItemBill(int BillNo)
        {

            return await billServiceRepository.GetCustomerItemBill( BillNo);
        }
        public async Task<ItemRequest> DELETECustomerItemBill(int BillNo)
        {

            return await billServiceRepository.DELETECustomerItemBill(BillNo);
        }
    }
}
