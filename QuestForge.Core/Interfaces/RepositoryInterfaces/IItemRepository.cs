using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(Guid itemId);
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> CreateItemAsync(Item item);
        Task<Item> UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid itemId);
        Task<IEnumerable<Item>> GetItemsByCampaignIdAsync(Guid campaignId);
    }
}
