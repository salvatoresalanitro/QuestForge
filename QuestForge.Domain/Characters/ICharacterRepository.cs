namespace QuestForge.Domain.Characters
{
    public interface ICharacterRepository
    {
        Task<Character?> GetByIdAsync(Guid characterId, CancellationToken cancellationToken);
        Task<IEnumerable<Character>> GetAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(Character character, CancellationToken cancellationToken);
        Task UpdateAsync(Character character);
        Task DeleteAsync(Character character);
    }
}
