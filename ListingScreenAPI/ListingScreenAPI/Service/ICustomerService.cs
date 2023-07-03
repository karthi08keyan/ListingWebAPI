using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Repository;

namespace ListingScreenAPI.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerRequest>> GetCustomer(int CustomerId);

        Task<bool> DeleteCustomer(int CustomerId);

        Task<CustomerRequest> AddCustomer(CustomerRequest customer);

    }
}
