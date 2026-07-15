namespace QuestForge.Domain.ValueObjects
{
    public interface ISpeciesRepository
    {
        Task<Species?> GetByIdAsync(int id);
        Task<IEnumerable<Species>> GetAllAsync();
    }
}