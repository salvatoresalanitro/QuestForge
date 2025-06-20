using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        public Task<Item> CreateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemByIdAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsByCampaignIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
