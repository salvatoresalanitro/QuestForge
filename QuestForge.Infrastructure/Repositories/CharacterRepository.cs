using Microsoft.EntityFrameworkCore;
using QuestForge.Domain.Characters;
using QuestForge.Infrastructure.Data;
using QuestForge.Infrastructure.Mapping;
using QuestForge.Infrastructure.Models;

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

        public async Task DeleteAsync(Character character, CancellationToken cancellationToken)
        {
            _context.Characters.Remove(character.MapToModel());
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Character>> GetAllAsync(CancellationToken cancellationToken)
        {
            var characters = await _context.Characters
                .Include(c => c.Species)
                    .ThenInclude(s => s.AllSubSpecies)
                .Include(c => c.Class)
                    .ThenInclude(c => c.SubClasses)
                .Include(c => c.Items)
                .Select(c => c.MapToDomain())
                .ToListAsync(cancellationToken);

            return characters;
        }

        public async Task<Character?> GetByIdAsync(Guid characterId, CancellationToken cancellationToken)
        {
            var hero = await _context.Characters
                .Include(c => c.Species)
                    .ThenInclude(s => s.AllSubSpecies)
                .Include(c => c.Class)
                    .ThenInclude(c => c.SubClasses)
                .Include(c => c.Items)
                .FirstOrDefaultAsync(character => character.Id == characterId, cancellationToken);

            return hero?.MapToDomain();
        }

        public async Task UpdateAsync(Character character, CancellationToken cancellationToken)
        {
            var modelTracked = _context.ChangeTracker.Entries<CharacterModel>()
                .First(model => model.Entity.Id == character.Id.Value).Entity;
            UpdateModelTracked(character, modelTracked);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private static void UpdateModelTracked(Character character, CharacterModel modelTracked)
        {
            modelTracked.Name = character.Name.Value;
            modelTracked.Level = character.Level.Value;
            modelTracked.HitPoints = character.HitPoints.Value;
            modelTracked.ArmorClass = character.ArmorClass.Value;
            modelTracked.SpeciesId = character.Species.Id;
            modelTracked.ClassId = character.Class.Id;

            modelTracked.Items.Clear();

            modelTracked.Items.AddRange(character.Items.Select(i => i.MapToModel()));
        }
    }
}
