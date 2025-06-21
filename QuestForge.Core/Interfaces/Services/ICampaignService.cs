using QuestForge.Core.DTOs.DTOsCampaign;

namespace QuestForge.Core.Interfaces.Services
{
    public interface ICampaignService
    {
        Task<CampaignDto> GetByIdAsync(Guid campaignId);
        Task<IEnumerable<CampaignDto>> GetAllAsync();
        Task CreateAsync(CreateCampaignDto campaign);
        Task<CampaignDto> UpdateAsync(CampaignDto campaign);
        Task DeleteAsync(CampaignDto campaign);
    }
}
