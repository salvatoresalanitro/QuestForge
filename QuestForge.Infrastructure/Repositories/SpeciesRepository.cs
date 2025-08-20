using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.ValueObjects;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;

namespace QuestForge.Infrastructure.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly QuestForgeContext _context;

        public SpeciesRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Species>> GetAllAsync()
        {
            var species = await _context.AllSpecies
                .Include(s => s.AllSubSpecies)
                .Select(s => s.MapToDomain())
                .ToListAsync();

            return species;
        }

        public async Task<Species?> GetByIdAsync(int id)
        {
            var entity = await _context.AllSpecies
                .AsNoTracking()
                .Include(s => s.AllSubSpecies)
                .FirstOrDefaultAsync(s => s.Id == id);

            return entity?.MapToDomain();
        }
    }
}