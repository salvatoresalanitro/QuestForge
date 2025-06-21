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

        public async Task<Character?> UpdateAsync(Character character)
        {
            var hero = await _context.Characters.FirstOrDefaultAsync(c => c.Id == character.Id);

            if(hero != null)
            {
                hero.ArmorClass = character.ArmorClass;
                hero.Class = character.Class;
                hero.Name = character.Name;
                hero.Items = character.Items;
                hero.Level = character.Level;
                hero.Species = character.Species;
                hero.HitPoints = character.HitPoints;
            }

            await _context.SaveChangesAsync();

            return hero;
        }
    }
}
