using QuestForge.Core.DTOs.DTOsCampaign;

namespace QuestForge.Core.Interfaces.Services
{
    public interface ICampaignService
    {
        Task<CampaignDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CampaignDto>> GetAllAsync();
        Task<CampaignDto> CreateAsync(CreateCampaignDto createDto);
        Task<CampaignDto> UpdateAsync(CampaignDto dto);
        Task DeleteAsync(CampaignDto dto);
    }
}
