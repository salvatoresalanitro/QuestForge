namespace QuestForge.Domain.ValueObjects
{
    public interface IClassRepository
    {
        Task<Class?> GetByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllAsync();
    }
}