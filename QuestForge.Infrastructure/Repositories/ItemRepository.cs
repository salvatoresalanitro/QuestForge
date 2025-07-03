using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> CreateAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetByIdAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetByCampaignIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
