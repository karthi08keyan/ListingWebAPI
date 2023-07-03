using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Repository;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.OpenApi.Any;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

namespace ListingScreenAPI.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

        }
     


        public async Task<IEnumerable<CustomerRequest>> GetCustomer(int CustomerId)
        {
            return await _customerRepository.GetCustomer(CustomerId);
        }
        public async Task<bool> DeleteCustomer(int CustomerId)
        {
            bool delete = await _customerRepository.DeleteCustomer(CustomerId);
            return delete;
        }
        public async Task<CustomerRequest> AddCustomer(CustomerRequest customer)
        {
            return await _customerRepository.AddCustomer(customer);
        }
    }
}
