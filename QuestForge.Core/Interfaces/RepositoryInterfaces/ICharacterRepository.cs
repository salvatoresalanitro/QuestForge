using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(Guid characterId);
        Task AddAsync(Character character);
        Task<Character?> UpdateAsync(Character character);
        Task DeleteAsync(Character character);
    }
}
