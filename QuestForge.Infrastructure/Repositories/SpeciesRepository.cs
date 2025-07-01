using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;

namespace QuestForge.Infrastructure.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly QuestForgeContext _context;

        public SpeciesRepository(QuestForgeContext context)
        {
            _context = context;
        }
        public async Task<Species?> GetByIdAsync(int id)
        {
            var species = await _context.Species.FirstOrDefaultAsync();

            return species;
        }

        public async Task<IEnumerable<Species>> GetAllAsync()
        {
            return await _context.Species.ToListAsync();
        }
    }
}
