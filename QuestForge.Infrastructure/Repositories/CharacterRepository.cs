using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.Characters;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;

namespace QuestForge.Infrastructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly QuestForgeContext _context;
        public CharacterRepository(QuestForgeContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Character character, CancellationToken cancellationToken)
        {
            await _context.Characters.AddAsync(character.MapToModel(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Character character)
        {
            _context.Characters.Remove(character.MapToModel());
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetAllAsync(CancellationToken cancellationToken)
        {
            var characters = await _context.Characters
                .Include(c => c.Species)
                .Include(c => c.Class)
                .Include(c => c.Items)
                .Select(c => c.MapToDomain())
                .ToListAsync(cancellationToken);

            return characters;
        }

        public async Task<Character?> GetByIdAsync(Guid characterId)
        {
            var hero = await _context.Characters.FirstOrDefaultAsync(character => character.Id == characterId);

            return hero?.MapToDomain();
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character.MapToModel());

            await _context.SaveChangesAsync();
        }
    }
}
