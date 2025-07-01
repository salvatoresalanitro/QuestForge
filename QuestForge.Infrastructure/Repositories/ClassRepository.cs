using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;

namespace QuestForge.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly QuestForgeContext _context;

        public ClassRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            var classes = await _context.Classes.FirstOrDefaultAsync();

            return classes;
        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}
