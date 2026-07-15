namespace QuestForge.Domain.Items
{
    public interface IItemRepository
    {
        Task<Item?> GetByIdAsync(Guid itemId);
        Task<IEnumerable<Item>> GetAllAsync();
        Task AddAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Item item);
        Task<IEnumerable<Item>> GetByCampaignIdAsync(Guid campaignId);
    }
}
