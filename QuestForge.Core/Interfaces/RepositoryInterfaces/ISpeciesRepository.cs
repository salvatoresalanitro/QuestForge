using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface ISpeciesRepository
    {
        Task<Species?> GetByIdAsync(int id);
        Task<IEnumerable<Species>> GetAllAsync();
    }
}
