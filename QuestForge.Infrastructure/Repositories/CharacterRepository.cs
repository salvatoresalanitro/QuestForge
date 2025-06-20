using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        public Task<Character> CreateCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCharacterAsync(Guid characterId)
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetCharacterByIdAsync(Guid characterId)
        {
            throw new NotImplementedException();
        }

        public Task<Character> UpdateCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
