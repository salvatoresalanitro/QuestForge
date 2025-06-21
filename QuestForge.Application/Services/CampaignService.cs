using AutoMapper;
using QuestForge.Core.DTOs.DTOsCampaign;
using QuestForge.Core.Entities;
using QuestForge.Core.Interfaces.RepositoryInterfaces;
using QuestForge.Core.Interfaces.Services;

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

        public async Task DeleteAsync(CampaignDto dto)
        {
            var campaign = _mapper.Map<Campaign>(dto);
            await _repository.DeleteAsync(campaign);
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

        public async Task<CampaignDto> UpdateAsync(CampaignDto dto)
        {
            var campaign = _mapper.Map<Campaign>(dto);
            var updatedCampaign = await _repository.UpdateAsync(campaign);

            return _mapper.Map<CampaignDto>(campaign);
        }
    }
}
