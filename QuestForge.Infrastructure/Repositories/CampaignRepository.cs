using QuestForge.Core.Entities;
using QuestForge.Core.RepositoryInterfaces;

namespace QuestForge.Infrastructure.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        public Task<Campaign> CreateCampaignAsync(Campaign campaign)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCampaignAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Campaign>> GetAllCampaignAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Campaign> GetCampaignByIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>> GetCharactersByCampaignIdAsync(Guid campaignId)
        {
            throw new NotImplementedException();
        }

        public Task<Campaign> UpdateCampaignAsync(Campaign campaign)
        {
            throw new NotImplementedException();
        }
    }
}
