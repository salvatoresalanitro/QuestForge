using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;

namespace QuestForge.Infrastructure.Repositories
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private readonly QuestForgeContext _context;

        public ItemTypeRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemType>> GetAllAsync()
        {
            return await _context.ItemTypes.ToListAsync();
        }

        public async Task<ItemType?> GetByIdAsync(int id)
        {
            return await _context.ItemTypes.FindAsync(id);
        }
    }
}
