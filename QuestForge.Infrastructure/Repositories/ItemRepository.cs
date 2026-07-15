using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.Items;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;

namespace QuestForge.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly QuestForgeContext _context;

        public ItemRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item.MapToModel());

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Item item)
        {
            _context.Items.Remove(item.MapToModel());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _context.Items.Select(i => i.MapToDomain()).ToListAsync();

            return items;
        }

        public async Task<Item?> GetByIdAsync(Guid itemId)
        {
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);

            return item?.MapToDomain();
        }

        public async Task<IEnumerable<Item>> GetByCampaignIdAsync(Guid campaignId)
        {
            var items = await _context.Items
                .Where(i => i.Campaign != null && i.Campaign.Id == campaignId)
                .Select(i => i.MapToDomain())
                .ToListAsync();

            return items;
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Items.Update(item.MapToModel());

            await _context.SaveChangesAsync();
        }
    }
}
