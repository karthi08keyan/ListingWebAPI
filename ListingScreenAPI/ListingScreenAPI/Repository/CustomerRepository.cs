using Dapper;
using System.Data.SqlClient;
using System.Data;
using ListingScreenAPI.Model.DataContract.Request;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using ListingScreenAPI.Model;

namespace ListingScreenAPI.Repository
{
    public class CustomerRepository:ICustomerRepository
    {

        private readonly Connection _connection;

        public CustomerRepository(Connection connection)
        {
            _connection = connection;
        }
       

        public async Task<IEnumerable<CustomerRequest>> GetCustomer(int Customerid)
        {
            IEnumerable<CustomerRequest> ListofCustomer;
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", Customerid);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {

                try
                {
                    ListofCustomer = await sqlConnection.QueryAsync<CustomerRequest>("SP_GetCustomers", parameters, commandType: CommandType.StoredProcedure);
                    return ListofCustomer;
                }
                catch (Exception)
                {
                    throw;
                }
               
            }

        }
        public async Task<bool> DeleteCustomer(int CustomerId)
        {
            bool delete = false;
            var parameters = new DynamicParameters();
            parameters.Add("customerId", CustomerId);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
               
                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_DeleteCustomer", parameters, commandType: CommandType.StoredProcedure);
                    if (result != 0)
                    {
                        delete = true;
                    }
                    else if (result == 0)
                    {
                        delete = false;
                    }
                }

                catch (Exception)
                {
                    throw;
                }
               
            }
            return delete;
        }
        public async Task<CustomerRequest> AddCustomer(CustomerRequest customer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customer.CustomerId);
            parameters.Add("CustomerName", customer.CustomerName);
            parameters.Add("Address", customer.Address);
            parameters.Add("Street", customer.Street);
            parameters.Add("City", customer.City);
            parameters.Add("Pincode", customer.PinCode);
            parameters.Add("MobileNumber", customer.MobileNumber);
            parameters.Add("Email", customer.Email);
            parameters.Add("OutstandingAmount", customer.OutstandingAmount);
            parameters.Add("OutstandingLimit", customer.OutstandingLimit);

            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
               
                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_AddCustomer", parameters, commandType: CommandType.StoredProcedure);
                    if (customer.CustomerId == 0)
                    {
                        customer.status = "Saved  Successfully..!";
                    }
                    else
                    {
                        customer.status = "Update Successfully..!";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
              
            }
            return customer;




        }
    }
}
