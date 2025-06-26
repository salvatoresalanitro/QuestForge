using QuestForge.Application.Interfaces;
using QuestForge.Application.Mapping;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _repository;

        public CampaignService(ICampaignRepository repository)
        {
            _repository = repository;
        }

        public async Task<CampaignDto> CreateAsync(CreateCampaignDto createDto)
        {
            var campaign = CampaignMapper.ToEntity(createDto);
            await _repository.AddAsync(campaign);

            return CampaignMapper.ToDto(campaign);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var campaign = await _repository.GetByIdAsync(id);
            if(campaign is null)
            {
                return false;
            }

            await _repository.DeleteAsync(campaign);
            return true;
        }

        public async Task<IEnumerable<CampaignDto>> GetAllAsync()
        {
            var campaigns = await _repository.GetAllAsync();

            return campaigns.Select(c => CampaignMapper.ToDto(c));
        }

        public async Task<CampaignDto?> GetByIdAsync(Guid id)
        {
            var campaign = await _repository.GetByIdAsync(id);
            return campaign is null ? null : CampaignMapper.ToDto(campaign);
        }

        public async Task<CampaignDto?> UpdateAsync(Guid id, CreateCampaignDto createDto)
        {
            var campaign = await _repository.GetByIdAsync(id);
            if (campaign is null)
            {
                return null;
            }

            campaign.Name = createDto.Name;
            campaign.Description = createDto.Description;

            await _repository.UpdateAsync(campaign);
            return CampaignMapper.ToDto(campaign);
        }
    }
}
