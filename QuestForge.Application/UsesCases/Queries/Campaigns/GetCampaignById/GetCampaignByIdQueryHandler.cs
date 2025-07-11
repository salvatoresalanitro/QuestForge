using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Campaigns;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Queries.Campaigns.GetCampaignById
{
    public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, CampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;

        public GetCampaignByIdQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<CampaignDto> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.GetByIdAsync(request.Id);

            return campaign is null
                ? throw new CampaignNotFoundException("Campaign not found.")
                : CampaignMapper.ToDto(campaign);
        }
    }
}
