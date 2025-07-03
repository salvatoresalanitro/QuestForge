using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface IItemTypeRepository
    {
        Task<ItemType?> GetByIdAsync(int id);
        Task<IEnumerable<ItemType>> GetAllAsync();
    }
}
