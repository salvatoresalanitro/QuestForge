using QuestForge.Core.Entities;

namespace QuestForge.Core.Interfaces.RepositoryInterfaces
{
    public interface ICampaignRepository
    {
        Task<Campaign> GetCampaignByIdAsync(Guid campaignId);
        Task<IEnumerable<Campaign>> GetAllCampaignAsync();
        Task<Campaign> CreateCampaignAsync(Campaign campaign);
        Task<Campaign> UpdateCampaignAsync(Campaign campaign);
        Task DeleteCampaignAsync(Guid campaignId);
        Task<IEnumerable<Character>> GetCharactersByCampaignIdAsync(Guid campaignId);
    }
}
