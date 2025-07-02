using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface ICampaignRepository
    {
        Task<Campaign?> GetByIdAsync(Guid campaignId);
        Task<IEnumerable<Campaign>> GetAllAsync();
        Task AddAsync(Campaign campaign);
        Task UpdateAsync(Campaign campaign);
        Task DeleteAsync(Campaign campaign);
    }
}
