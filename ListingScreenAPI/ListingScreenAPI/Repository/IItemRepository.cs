using ListingScreenAPI.Model.DataContract.Request;

namespace ListingScreenAPI.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<ItemRequest>> GetItems(int ItemId);
        Task<bool> DeleteItem(int ItemId);
        Task<ItemRequest> AddItem(ItemRequest item);
    }
}
