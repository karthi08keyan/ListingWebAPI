using ListingScreenAPI.Model.DataContract.Request;

namespace ListingScreenAPI.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerRequest>> GetCustomer(int Customerid);
        Task<bool> DeleteCustomer(int CustomerId);
        Task<CustomerRequest> AddCustomer(CustomerRequest customer);
    }
}
