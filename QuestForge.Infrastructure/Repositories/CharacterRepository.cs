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

        public async Task AddAsync(Character character)
        {
            await _context.Characters.AddAsync(character.MapToModel());
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Character character)
        {
            _context.Characters.Remove(character.MapToModel());
            await _context.SaveChangesAsync();
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
