using Dapper;
using ListingScreenAPI.Model.DataContract.Request;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using ListingScreenAPI.Model;

namespace ListingScreenAPI.Repository
{
    public class ItemRepository:IItemRepository
    {
       
        private readonly Connection _connection;

        public ItemRepository(Connection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<ItemRequest>> GetItems(int ItemId)
            {
            
            IEnumerable<ItemRequest> ListOfItems;
            var parameters = new DynamicParameters();
            parameters.Add("ItemId", ItemId);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {
                try
                {
                    ListOfItems = await sqlConnection.QueryAsync<ItemRequest>("SP_GetItems", parameters, commandType: CommandType.StoredProcedure);
                    return ListOfItems;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
        public async Task<bool> DeleteItem(int ItemId)
        {
            bool delete = false;
            var parameters = new DynamicParameters();
            parameters.Add("ItemId", ItemId);
            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {

                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_DeleteItem", parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<ItemRequest> AddItem(ItemRequest item)
        {


            var parameters = new DynamicParameters();
            parameters.Add("@ItemId", item.ItemId);
            parameters.Add("@ItemName", item.ItemName);
            parameters.Add("@Price", item.Price);
            parameters.Add("@Stock", item.Stock);
            parameters.Add("@ItemCode", item.ItemCode);
            parameters.Add("@GST", item.GST);

            using (SqlConnection sqlConnection = _connection.GetDbConnection())
            {

                try
                {
                    var result = await sqlConnection.ExecuteAsync("SP_AddItems", parameters, commandType: CommandType.StoredProcedure);
                    if (item.ItemId == 0)
                    {
                        item.status = "Saved  Successfully..!";
                    }
                    else
                    {
                        item.status = "Update Successfully..!";
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return item;

        }
    }
}
