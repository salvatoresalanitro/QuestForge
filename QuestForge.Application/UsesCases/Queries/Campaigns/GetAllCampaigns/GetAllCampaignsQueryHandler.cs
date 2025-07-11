using MediatR;
using QuestForge.Application.Exceptions;
using QuestForge.Application.Mapping;
using QuestForge.Domain.Campaigns;
using QuestForge.DTOs.DTOsCampaign;

namespace QuestForge.Application.UsesCases.Queries.Campaigns.GetAllCampaigns
{
    public sealed record GetAllCampaignsQueryHandler : IRequestHandler<GetAllCampaignsQuery, IEnumerable<CampaignDto>>
    {
        private readonly ICampaignRepository _campaignRepository;

        public GetAllCampaignsQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<IEnumerable<CampaignDto>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
        {
            var campaigns = await _campaignRepository.GetAllAsync(cancellationToken);

            return campaigns is null
                ? throw new CampaignNotFoundException("No campaigns found.")
                : campaigns.Select(c => CampaignMapper.ToDto(c));
        }
    }
}
