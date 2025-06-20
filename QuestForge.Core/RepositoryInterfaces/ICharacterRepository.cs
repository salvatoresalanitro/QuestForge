using QuestForge.Core.Entities;

namespace QuestForge.Core.RepositoryInterfaces
{
    public interface ICharacterRepository
    {
        Task<Character> GetCharacterByIdAsync(Guid characterId);
        Task<Character> CreateCharacterAsync(Character character);
        Task<Character> UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(Guid characterId);
    }
}
