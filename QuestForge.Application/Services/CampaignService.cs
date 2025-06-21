using AutoMapper;
using QuestForge.Application.Interfaces;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _repository;
        private readonly IMapper _mapper;

        public CampaignService(ICampaignRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CampaignDto> CreateAsync(CreateCampaignDto createDto)
        {
            var campaign = _mapper.Map<Campaign>(createDto);
            await _repository.AddAsync(campaign);

            return _mapper.Map<CampaignDto>(campaign);
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

            return campaigns.Select(c => _mapper.Map<CampaignDto>(c));
        }

        public async Task<CampaignDto?> GetByIdAsync(Guid id)
        {
            var campaign = await _repository.GetByIdAsync(id);
            return campaign is null ? null : _mapper.Map<CampaignDto>(campaign);
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
            return _mapper.Map<CampaignDto>(campaign);
        }
    }
}
