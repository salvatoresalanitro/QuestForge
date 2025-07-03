using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface IItemRepository
    {
        Task<Item> GetByIdAsync(Guid itemId);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> CreateAsync(Item item);
        Task<Item> UpdateAsync(Item item);
        Task DeleteAsync(Guid itemId);
        Task<IEnumerable<Item>> GetByCampaignIdAsync(Guid campaignId);
    }
}
