using Dapper;
using ListingScreenAPI.Model.DataContract.Request;
using ListingScreenAPI.Repository;
using System.Data;
using System.Data.SqlClient;

namespace ListingScreenAPI.Service
{
    public class ItemService:IItemService
    {

        private readonly IItemRepository itemRepository;

        public ItemService(IItemRepository itemRepositor)
        {
            itemRepository = itemRepositor;
        }
     
        public async Task<IEnumerable<ItemRequest>> GetItems(int ItemId)
        {

            IEnumerable<ItemRequest> ListOfItems = await itemRepository.GetItems(ItemId);
            return ListOfItems;
        }

        public async Task<bool> DeleteItem(int ItemId)  
        {
            bool delete = await itemRepository.DeleteItem(ItemId);
            return delete;
        }
        public async Task<ItemRequest> AddItem(ItemRequest item)
        {
            return await itemRepository.AddItem(item);
        }
    }
}