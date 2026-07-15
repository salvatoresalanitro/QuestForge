using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;

namespace QuestForge.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly QuestForgeContext _context;

        public ClassRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            var classes = await _context.Classes
                .Include(c => c.SubClasses)
                .Select(c => c.MapToDomain())
                .ToListAsync();

            return classes;
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            var entity = await _context.Classes
                .AsNoTracking()
                .Include(c => c.SubClasses)
                .FirstOrDefaultAsync(c => c.Id == id);

            return entity?.MapToDomain();
        }
    }
}