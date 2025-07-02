using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface IClassRepository
    {
        Task<Class?> GetByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllAsync();
    }
}
