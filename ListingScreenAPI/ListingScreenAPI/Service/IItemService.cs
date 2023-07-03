using ListingScreenAPI.Model.DataContract.Request;

namespace ListingScreenAPI.Service
{
    public interface IItemService
    {
        Task<IEnumerable<ItemRequest>> GetItems(int ItemId);
        Task<bool> DeleteItem(int ItemId);
        Task<ItemRequest> AddItem(ItemRequest item);

    }
}
