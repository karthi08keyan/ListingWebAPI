using Dapper;
using ListingScreenAPI.Model;
using ListingScreenAPI.Model.DataContract.Request;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;

namespace ListingScreenAPI.Repository
{
    public class BillServiceRepository : IBillServiceRepository
    {
        private Connection _connection;

        public BillServiceRepository(Connection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<BillRequest>> GetBillNumber(string billNo)
        {

            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
                IEnumerable<BillRequest> newBilNo;
                if (billNo == "none")
                {
                    try
                    {

                        newBilNo = await sqlConnection.QueryAsync<BillRequest>("SP_AddBillNumber", commandType: CommandType.StoredProcedure);
                        return newBilNo;

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return null;


            }

        }

        public async Task<CustomerBillRequest> PostCustomer(CustomerBillRequest customer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("BillId", customer.BillId);
            parameters.Add("CustomerName", customer.CustomerName);
            parameters.Add("OutstandingAmount", customer.OutstandingAmount);
            parameters.Add("OutstandingLimit", customer.OutstandingLimit);
            parameters.Add("CustomerDetails", customer.CustomerDetails);
            parameters.Add("Billno", customer.Billno);
            parameters.Add("BillDate", customer.BillDate);
            parameters.Add("PaymentType", customer.PaymentType);
            parameters.Add("TotalAmount", customer.TotalAmount);
            parameters.Add("Mode", customer.Mode);
            parameters.Add("@InsertedBillId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
                try
                {

                    var result = await sqlConnection.ExecuteAsync("SP_AddCustomerBill", parameters, commandType: CommandType.StoredProcedure);

                    if (customer.Mode == "INSERT")
                    {
                        int insertedBillId = parameters.Get<int>("@InsertedBillId");
                        customer.BillId = insertedBillId;
                        customer.status = "Saved Successfully..!";

                    }



                    else if (customer.Mode == "UPDATE")
                    {
                        customer.status = "Update Successfully..!";
                    }
                    else if (customer.Mode == "DELETE")
                    {
                        customer.status = "Delete Successfully..!";
                    }
                    else
                    {
                        //var val = await sqlConnection.QueryAsync<CustomerBillRequest>("SP_AddCustomerBill", parameters, commandType: CommandType.StoredProcedure);
                        // customer = val.FirstOrDefault();
                        // customer.status = "Get Customer Successfully..!";
                    }

                }
                catch (Exception ex)
                {

                }
            }
            return customer;
        }
        public async Task<ItemRequest> PostCustomerItemBill(ItemRequest customerItemBill)
        {

            var parameters = new DynamicParameters();

            parameters.Add("ItemName", customerItemBill.ItemName);
            parameters.Add("ItemId", customerItemBill.ItemId);
            parameters.Add("ItemCode", customerItemBill.ItemCode);
            parameters.Add("Price", customerItemBill.Price);
            parameters.Add("Stock", customerItemBill.Stock);
            parameters.Add("GST", customerItemBill.GST);
            parameters.Add("BillNo", customerItemBill.BillNo);
            parameters.Add("Value", customerItemBill.Value);
            parameters.Add("GSTValue", customerItemBill.GSTValue);
            parameters.Add("Amount", customerItemBill.Amount);
            parameters.Add("Mode", customerItemBill.Mode);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_CustomerItemBill", parameters, commandType: CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return customerItemBill;
        }

        public async Task<IEnumerable<ItemRequest>> GetCustomerItemBill(int BillNo)
        {
            IEnumerable<ItemRequest> Billitems;
            ItemRequest itemRequest = new ItemRequest();
            var parameters = new DynamicParameters();
            itemRequest.Mode = "GET";
            itemRequest.BillNo = BillNo;
            parameters.Add("Mode", itemRequest.Mode);
            parameters.Add("BillNo", itemRequest.BillNo);

            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {

                try
                {

                    Billitems = await sqlConnection.QueryAsync<ItemRequest>("SP_CustomerItemBill", parameters, commandType: CommandType.StoredProcedure);

                    return Billitems;
                }
                catch (Exception ex)
                {
                    throw;
                }




            }

        }

        public async Task<ItemRequest> DELETECustomerItemBill(int ItemId)
        {
            ItemRequest itemRequest = new ItemRequest();
            var parameters = new DynamicParameters();
            itemRequest.Mode = "DELETE";
            itemRequest.ItemId = ItemId;
            parameters.Add("Mode", itemRequest.Mode);
            parameters.Add("ItemId", itemRequest.ItemId);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {

                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_CustomerItemBill", parameters, commandType: CommandType.StoredProcedure);
                    itemRequest.status = "Delete succussfully";
                    return itemRequest;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

        }
    }
}
