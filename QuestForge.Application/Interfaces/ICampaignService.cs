using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.Interfaces
{
    public interface ICampaignService
    {
        Task<CampaignDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CampaignDto>> GetAllAsync();
        Task<CampaignDto> CreateAsync(CreateCampaignDto createDto);
        Task<CampaignDto?> UpdateAsync(Guid id, CreateCampaignDto createDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
