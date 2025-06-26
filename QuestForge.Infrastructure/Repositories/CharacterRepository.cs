using Microsoft.EntityFrameworkCore;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Infrastructure.Data;

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
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Character character)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<Character?> GetByIdAsync(Guid characterId)
        {
            var hero = await _context.Characters.FirstOrDefaultAsync(character => character.Id == characterId);

            return hero;
        }

        public async Task UpdateAsync(Character character)
        {
            _context.Characters.Update(character);

            await _context.SaveChangesAsync();
        }
    }
}
